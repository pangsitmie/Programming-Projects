import pickle, struct, socket, cv2

host ='127.0.0.1'
port = 9999

# Socket Create
server_socket = sctp.sctpsocket_tcp(socket.AF_INET)
bufsize = server_socket.getsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF)
print ("BUffer size [Before]: %d" %bufsize)
server_socket.setsockopt(
	socket.SOL_SOCKET,
	socket.SO_SNDBUF,
	3000000)

bufsize = server_socket.getsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF)
print ("BUffer size [Before]: %d" %bufsize)

server_socket.bind((host,port))
server_socket.listen(1)
print("Listening at", (host, port))

ls = []
while True:
	client_socket, addr = server_socket.accept()
	print ('get connection from:', addr)

	if client_socket:
		vid = cv2.VideoCapture(0)
		while vid.isOpened():
			img, frame = vid.read()
			a = pickle.dumps(frame)
			message = struct.pack("Q", len(a))
			print(len(a))

			ls.clear()
			ls+=[message[:]]
			ls+=[a[i:i+210000] for i in range(len(a)) if i% 210000 == 0]

			for item in ls:
				client_socket.sendall(item)


			cv2.imshow('transmitting video', frame)
			key= cv2.waitKey(1) & 0xFF
			if key == ord('q'):
				client_socket.close()