import json
from socket import AF_INET, socket, SOCK_STREAM


class Client:
    __SOCKET = socket(AF_INET, SOCK_STREAM)
    __BUFFER_SIZE = 1024

    def __init__(self, host, port):
        self._host = host
        self._port = port
        self.__SOCKET.connect((self._host, self._port))

    def request(self, data):
        self.__SOCKET.send(bytes(data, "utf8"))
        return json.loads(self.__SOCKET.recv(self.__BUFFER_SIZE).decode("utf8"))


client = Client("192.168.11.104", 8080)
while True:
    message = input("Enter message - ")
    respond = client.request(json.dumps({"Type": "Output",
                                         "Data": {"Message": message}}))
    print("Server - {0}".format(respond["Data"]["Message"]))
