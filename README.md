# TcpServerClient

    Multi Client dengan Multithread TCP 

Cara Kerja

Server

  - Menjalankan Server 
  - Server menunggu permintaan masuk client
  - Server menerima permintaan masuk client
  - Client yang baru masuk ditambahkan ke list dan di masukkan ke thread baru
  - Server menerima input nama dan pesan dari tiap client
  - Server melakukan broadcast input client ke semua client lain yang berbeda
  - Chat setiap client yang terkirim ke server di simpan dalam bentuk .txt
  - Client yang disconnect akan dihapus dari list
  - Server akan otomatis ditutup jika tidak terdapat clientlist

Client

  - Menjalankan Client
  - Client meminta request ke server
  - Request ke server diterima
  - Clien akan menerima broadcast yang ada dari server
  - client menginput nama dan pesan yang akan dikirim ke server
  - input dari client masuk ke server
  - input yang masuk akan di broadcast ke semua client selain pengirim
  - client ditutup

Flowchart Server

![TcpServer](https://user-images.githubusercontent.com/63985999/125169945-b45a4d80-e1d6-11eb-931a-18a1ed6c0b4f.jpg)

Flowchart Client

![TcpClient(1)](https://user-images.githubusercontent.com/63985999/125170811-0bfab800-e1db-11eb-9e0a-1d151f3b37ea.jpg)


Output :

![OutputTCP](https://user-images.githubusercontent.com/63985999/125170097-6b56c900-e1d7-11eb-97e4-d67fb278d760.JPG)


