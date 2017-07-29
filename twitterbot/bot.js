const Twit = require('twit');
const Connection = require('tedious').Connection;
const TYPES = require('tedious').TYPES;
const Request = require('tedious').Request;
const emoji = require('node-emoji');

const numEvents = [0];

console.log('BOT ACTIVATED.\n');

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
        console.log('Connected to database.\n');
        execute();
    }
});

setInterval(execute, 10000);

function execute() {
    countEvents();
}

function countEvents() {
    console.log('\n\nCounting events...\n');

    request = new Request(
        "SELECT @count=(COUNT(*)) " + 
        "FROM dbo.Events ",
 
        function (err, rowCount, rows) {
            if (err) {
                console.log(err);
            } else {
                console.log('Query complete.\n');
            }
        }
    );

    request.addOutputParameter('count', TYPES.Int);

    request.on('returnValue', function (parameterName, value, metadata) {
        if (value > numEvents[numEvents.length - 1]) {
            console.log('New event found.\n');
            numEvents.push(value);
            postDirectMessage();
        } else {
            console.log('No new events.\n');
        }
    });

    connection.execSql(request);
}

function postDirectMessage() {
    twitterbot.post(
        'direct_messages/new', {
            user_id: '2889985308', // @ra_forero
            text: emoji.emojify(':warning: Your turret has been activated!'),
        },
        
        function (err, data, response) {
            if (err) {
                console.log(err);
            } else {
                console.log('Direct message sent to @ra_forero.\n');
            }
        }
    );
}
