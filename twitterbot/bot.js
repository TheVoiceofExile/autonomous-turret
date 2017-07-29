const Twit = require('twit');
const Connection = require('tedious').Connection;
const TYPES = require('tedious').TYPES;
const Request = require('tedious').Request;
const emoji = require('node-emoji');

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
        console.log('Connected to database.');
        execute();
    }
});

const execute = function () {
    countEvents();
}

setInterval(execute, 5000);

const countEvents = function () {
    console.log('Reading rows from table...');

    request = new Request(
        "SELECT @count=(COUNT(*)) " + 
        "FROM dbo.Events ",
 
        function (err, rowCount, rows) {
            if (err) {
                console.log(err);
            } else {
                console.log(rowCount + ' row(s) returned');
            }
        }
    );

    request.addOutputParameter('count', TYPES.Int);

    request.on('returnValue', function (parameterName, value, metadata) {
        console.log('Event Count: ' + value);
    });

    connection.execSql(request);
}

const postDirectMessage = function () {
    twitterbot.post(
        'direct_messages/new', {
            user_id: '2889985308', // @ra_forero
            text: emoji.emojify(':warning: Your turret has been activated!'),
        },
        
        function (err, data, response) {
            if (err) {
                console.log(err);
            } else {
                console.log('Direct message sent to @ra_forero.');
                // process.exit();
            }
        }
    );
}
