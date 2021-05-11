const express = require('express');
const bodyParser = require('body-parser');

const app = express();
const routes = require('./route');

app.use('/api', routes);

app.listen(3000, function () {
    console.log('The force may with you! Server running on port 3000')
})