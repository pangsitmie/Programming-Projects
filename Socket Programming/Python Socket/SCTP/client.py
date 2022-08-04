import pickle, struct, socket, cv2

host ='127.0.0.1'
port = 9999

# Socket Create
client_socket = sctp.sctpsocket_tcp(socket.AF_INET)
client_socket.connect(("127.0.0.1",9999))


data = b""
payload_size = struct.calcsize("Q")

while True:
	while len(data) < payload_size:
		packet = client_socket.recv(21000000)
		if not packet: break
		data += packet

	packet_msg_size = data[:payload_size]
	data = data[payload_size:]
	msg_size = struct.unpack("Q", packet_msg_size)[0]

	while len(data) < msg_size:
    	data += client_socket.recv(210000)
	frame_data = data[:msg_size]
	data = data[:msg_size]
	frame = pickle.loads(frame_data)
	cv2.imshow("Received", frame)
	key = cv2.waitKey(1)& 0xFF
	if key == ord('q'):
		client_socket.close()


