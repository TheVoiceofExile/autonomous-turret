const Twit = require('twit');
const emoji = require('node-emoji');

console.log("BOT ACTIVATED.");

const T = new Twit({
    consumer_key: 'BLMFmhRGVSbimKjFcvhKj28jL',
    consumer_secret: 'FWmV1rRWWIGBnrzfNQ2Uz2zRsJVTl73HGPD8qGdlxHb7nE6FLt',
    access_token: '878069495037919232-38XczPn1cBOBJmnQJIHLp5EqQCvZDGW',
    access_token_secret: 'tH4KDsmoXJgXZSURkHoaeNOu1JbsiGQajyCiclUeKn2y4',
});

/*
 * TODO: Query database
 * 
 * 
 */

T.post(
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
);
