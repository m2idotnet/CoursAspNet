var app = require("http").createServer(handler);

var io = require("socket.io")(app);

function handler(req, res) {
    res.writeHead(200);
    res.end();
}
io.on('connection', function (socket) {
    socket.on('newMessage', (data) => {
        socket.broadcast.emit('newMessage', data);
    });
});
app.listen(8000);