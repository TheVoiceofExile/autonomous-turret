const Twit = require('twit');
const emoji = require('node-emoji');
const Connection = require('tedious').Connection;
const Request = require('tedious').Request;

console.log("BOT ACTIVATED.");

/*
 * CONNECT TO AZURE DATABASE
 */
const config = {
    userName: 'ironicism',
    password: 'Unknown8*',
    server: 'softdev.database.windows.net',
    options: {
        port: 1433,
        encrypt: true,
        database: 'AutoTurret',
    }
}

const connection = new Connection(config);

connection.on('connect', function (err) {
    if (err) {
        console.log(err);
    } else {
        queryDatabase();
        // Format data
        // Post Twitter dm
    }
});

/*
 * TODO: QUERY DATA
 * - queryDatabase();
 * 
 */

/*
 * CONNECT TO TWITTER API
 */
const T = new Twit({
    consumer_key: 'BLMFmhRGVSbimKjFcvhKj28jL',
    consumer_secret: 'FWmV1rRWWIGBnrzfNQ2Uz2zRsJVTl73HGPD8qGdlxHb7nE6FLt',
    access_token: '878069495037919232-38XczPn1cBOBJmnQJIHLp5EqQCvZDGW',
    access_token_secret: 'tH4KDsmoXJgXZSURkHoaeNOu1JbsiGQajyCiclUeKn2y4',
});

/*
 * POST DIRECT MESSAGE
 */
/*T.post(
    'direct_messages/new', {
        user_id: '2889985308', // @ra_forero
        text: emoji.emojify('Hello I am Bot :hand: :robot_face:'),
    }, 
    function (err, data, response) {
        console.log('Message sent to @ra_forero.');
    }
);

T.post(
    'direct_messages/new', {
        user_id: '879129222618513408', // @brent_rademaker
        text: emoji.emojify('Hello I am Bot :hand: :robot_face:'),
    }, 
    function (err, data, response) {
        console.log('Message sent to @brent_rademaker.');
    }
);

T.post(
    'direct_messages/new', {
        user_id: '3622865902', // @billy_bil88
        text: emoji.emojify('Hello I am Bot :hand: :robot_face:'),
    }, 
    function (err, data, response) {
        console.log('Message sent to @billy_bil88.');
    }
);

T.post(
    'direct_messages/new', {
        user_id: '883285308', // @megamatt119
        text: emoji.emojify('Hello I am Bot :hand: :robot_face:'),
    }, 
    function (err, data, response) {
        console.log('Message sent to @megamatt119.');
    }
);*/
