const Twit = require('twit');
const emoji = require('node-emoji');
const Connection = require('tedious').Connection;
const Request = require('tedious').Request;

console.log('BOT ACTIVATED.');

const twitterbot = new Twit({
    consumer_key: 'BLMFmhRGVSbimKjFcvhKj28jL',
    consumer_secret: 'FWmV1rRWWIGBnrzfNQ2Uz2zRsJVTl73HGPD8qGdlxHb7nE6FLt',
    access_token: '878069495037919232-38XczPn1cBOBJmnQJIHLp5EqQCvZDGW',
    access_token_secret: 'tH4KDsmoXJgXZSURkHoaeNOu1JbsiGQajyCiclUeKn2y4',
});

const connection = new Connection({
    userName: 'TwitterLogin',
    password: 'Twitterbot8*',
    server: 'softdev.database.windows.net',
    options: {
        port: 1433,
        encrypt: true,
        database: 'AutoTurret',
    }
});

connection.on('connect', function (err) {
    if (err) {
        console.log(err);
    } else {
        console.log('Connected to database.')
        queryDatabase();
    }
});

const queryDatabase = function () { 
    console.log('Reading rows from table...');

    request = new Request(
        "SELECT COUNT(*) " + 
        "FROM dbo.Turrets, dbo.Events " + 
        "WHERE Turrets.turret_id = Events.fk_turret_id ",
 
        function (err, rowCount, rows) {
            if (err) {
                console.log(err);
            } else {
                console.log(rowCount + ' row(s) returned');
            }
        }
    );

    request.on('row', function (columns) {
        columns.forEach(function (column) {
            console.log('Number of events in turret: %s\t%s', column.metadata.colName, column.value);
            postDirectMessage(column.value);
        });
    });

    connection.execSql(request);
}

const postDirectMessage = function (queryOutput) {
    const numEvents = queryOutput;

    twitterbot.post(
        'direct_messages/new', {
            user_id: '2889985308', // @ra_forero
            text: emoji.emojify(`${numEvents} events in turret :hand: :robot_face:`),
        }, 
        function (err, data, response) {
            if (err) {
                console.log(err);
            } else {
                console.log('Direct message sent to @ra_forero.');
                process.exit();
            }
        }
    );
}
