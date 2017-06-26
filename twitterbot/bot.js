const Twit = require('twit');

console.log("BOT ACTIVATED.");

const T = new Twit({
    consumer_key: 'BLMFmhRGVSbimKjFcvhKj28jL',
    consumer_secret: 'FWmV1rRWWIGBnrzfNQ2Uz2zRsJVTl73HGPD8qGdlxHb7nE6FLt',
    access_token: '878069495037919232-38XczPn1cBOBJmnQJIHLp5EqQCvZDGW',
    access_token_secret: 'tH4KDsmoXJgXZSURkHoaeNOu1JbsiGQajyCiclUeKn2y4',
});

// TODO: Query database

T.post(
    'direct_messages/new', {
        user_id: '2889985308', // @ra_forero
        text: 'HELLO I AM BOT.',
    }, 
    function (err, data, response) {
        console.log('Message sent.');
    }
);

T.post(
    'direct_messages/new', {
        user_id: '879129222618513408', // @ brent_rademaker
        text: 'Hi Brent, this is Bot. This is a test message.',
    }, 
    function (err, data, response) {
        console.log('Message sent.');
    }
);

T.post(
    'direct_messages/new', {
        user_id: '3622865902', // @ billy_bil88
        text: 'Hi Billy, this is Bot. This is a test message.',
    }, 
    function (err, data, response) {
        console.log('Message sent.');
    }
);
