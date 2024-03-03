using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;





// namespace pebriKantin merupakan package dari program ini
namespace pebriKantin {                                                                                                                                                                                                                                                                              
    class program
    {
        public string email;
        public string konfirmasiPassword;
        static void Main()
        {
            bool loopingMenu = true;
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║ [1] Daftar Akun                  ║");
            Console.WriteLine("║ [2] Login Akun                   ║");
            Console.WriteLine("║ [3] Lupa Password                ║");
            Console.WriteLine("╠══════════════════════════════════╝");
            while (loopingMenu == true)
            {
                Console.WriteLine("║");
                Console.Write("╠═> Pilih: ");
                var pilih = Console.ReadLine();
                if(pilih == "1")
                {
                    loopingMenu = false;
                    daftar();
                }
                else if (pilih == "2")
                {
                    loopingMenu = false;
                    login();
                }
                else if (pilih == "3")
                {
                    loopingMenu = false;
                    lupaPassword();
                }
                else
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.Write("╠═> ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Maaf Inputan {pilih} Tidak Ada!");
                    Console.ResetColor();

                    Thread.Sleep(500);
                }
            }
            
        }


        // method daftar berfungsi untuk daftar bagi pengguna baru
        public static void daftar()
        {
      
            bool kondisi1 = true;
            // while kondisi1 berfungsi untuk melooping program jika password dengan konfirmasi password tidak sesuai valuenya
            while (kondisi1)
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║ Daftar Akun Kamu Di Sini!             ║");
                Console.WriteLine("║ Masukan Data Diri Anda Dengan Benar!  ║");
                Console.WriteLine("╠═══════════════════════════════════════╝");
                Console.WriteLine("║");
                Console.Write("╠═> Nama: ");
                var username = Console.ReadLine();

                // ketika karakter kurang dari 5 maka akan mengulang
                while (username.Length < 5)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.Write("╠═>");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Maaf Inputan minimal 5 karakter. Silakan coba lagi");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Console.Write("╠═> Nama: ");
                    username = Console.ReadLine();
                }
                Thread.Sleep(500);
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Masukan Email Anda");
                Thread.Sleep(500);
                Console.Write("╠═> Email: ");
                var email = Console.ReadLine();
                // ketika karakter kurang dari 1 maka akan mengulang
                while (email.Length < 1)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.Write("╠═>");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Maaf email minimal 1 karakter. Silakan coba lagi.");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Console.Write("╠═> Email: ");
                    email = Console.ReadLine();
                }
                Thread.Sleep(500);
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Masukan password Anda");
                System.Threading.Thread.Sleep(500);
                Console.Write("╠═> Password: ");
                var password = Console.ReadLine();
                // ketika karakter kurang dari 8 maka akan mengulang
                while (password.Length < 8)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.Write("╠═>");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Maaf Password minimal 8 karakter. Silakan coba lagi.");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.Write("╠═> Password: ");
                    password = Console.ReadLine();
                }

                // khusus program untuk password saya buat loop dan percabangan agar ketika pass tidak sesuai langsung di reset ulang passwordnya
                bool kondisiPassword = true;
                while (kondisiPassword == true)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine("╠═> Masukan ulang password Anda");
                    Thread.Sleep(500);
                    Console.Write("╠═> Password: ");
                    var konfirmasiPassword = Console.ReadLine();
                    if (password == konfirmasiPassword)
                    {
                        kondisiPassword = false;
                        kondisi1 = false;
                        DataConnection Kantin = new DataConnection();
                        Kantin.daftar(username, email, konfirmasiPassword);
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.Write("╠═>");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Maaf password yang anda masukan tidak sesuai dengan yang di atas!");
                        Console.ResetColor();
                        kondisi1 = false;
                    }
                }

            }
        }

        // method login berfungsi untuk login user
        public static void login()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║ login akun kamu Di Sini               ║");
            Console.WriteLine("╠═══════════════════════════════════════╝");
            Console.WriteLine("║");
            Console.WriteLine("╠═> Masukan email anda");
            Console.Write("╠═> Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("║");
            Console.WriteLine("╠═> Masukan password anda");
            Console.Write("╠═> Password: ");
            var password = Console.ReadLine();

            // object yang memanggil class
            DataConnection Kantin = new DataConnection();
            // Kantin.login(email, password); memanggil method override login berargumen di dalam class yang sudah di objectkan 
            Kantin.login(email, password);


        }

        // method lupa password berfungsi untuk mereset password
        public static void lupaPassword()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║ Lengkapi Data Untuk Reset Password        ║");
            Console.WriteLine("╠═══════════════════════════════════════════╝");
            Console.WriteLine("║");
            Console.WriteLine("╠═> Masukan Email Anda Untuk Reset Password!");
            Console.Write("╠═> Email: ");
            var email = Console.ReadLine();

            // object yang memanggil class
            DataConnection Kantin = new DataConnection();
            // Kantin.lupaPassword(email); memanggil method override lupaPassword berargumen di dalam class yang sudah di objectkan 
            Kantin.lupaPassword(email);
        }
    }

    public class parentKantin
    {
        // field untuk menyambungkan database
        private string server = "localhost";
        private string database = "csharplogin";
        private string uid = "root";
        private string pass = "";

        // field variabel kosong yang nantinya akan di deklarasikan
        private string queryLogin;
        private string queryDaftar;
        private string queryCheck;
        public string name;
        public string cekEmail;
        public string cekPW;
        public string status;
        public string sqlError;
        public int cetakidOtomatis;



        // virtual daftar untuk membuat user baru
        public virtual void daftar(string username, string email, string password)
        {
            string db = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            MySqlConnection connection = new MySqlConnection(db);

            // cek email apakah sudah di pakai apa belum
            try
            {
                connection.Open();
                queryCheck = $"SELECT * FROM data";
                MySqlCommand command = new MySqlCommand(queryCheck, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(2).ToString() == email) {
                        bool kondisiyt = true;
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.Write("╠═> ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Maaf email yang anda inputkan sudah terdaftar ke akun lain!");
                        Console.ResetColor();
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.WriteLine("╠═> Apakah anda ingin tetap mendaftar akun? y/t");
                        Thread.Sleep(500);
                        while (kondisiyt == true)
                        {
                            Console.Write("╠═> Pilih: ");
                            var pilihan = Console.ReadLine().ToLower();
                            if (pilihan == "y")
                            {
                                kondisiyt = false;
                                program.daftar();
                            }
                            else if (pilihan == "t")
                            {
                                kondisiyt = false;
                                Thread.Sleep(500);
                                Console.WriteLine($"║");
                                Thread.Sleep(500);
                                Console.WriteLine("╠═> Anda Telah Keluar Program!");
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine($"║");
                                Thread.Sleep(500);
                                Console.Write("╠═>");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Maaf inputan yang anda input tidak ada!");
                                Console.ResetColor();
                                Thread.Sleep(500);
                                Console.WriteLine("║");
                            }
                        }
                    }
                    cetakidOtomatis = reader.GetInt32(0);
                    cetakidOtomatis += 1;
                }
            }
            catch (MySqlException ex)
            {
                status = "errormysql";
                sqlError = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            // create data baru
            try
            {
                connection.Open();
                queryDaftar = $"INSERT INTO data (id, username, email, password) VALUES('{cetakidOtomatis}', '{username}', '{email}', '{password}') ";
                MySqlCommand command = new MySqlCommand(queryDaftar, connection);
                int tambahkan = command.ExecuteNonQuery();
                if (tambahkan > 0)
                {
                    status = "tambahkan";
                }
                else
                {
                    status = "gagalTambahkan";
                }

            }
            catch (MySqlException ex)
            {
                status = "errormysql";
                sqlError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }


        // virtual login untuk memproses data dari databse yang nantinya di kirim ke override
        public virtual void login(string email, string password)
        {
            string db = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            MySqlConnection connection = new MySqlConnection(db);
            try
            {
                connection.Open();
                queryLogin = $"SELECT * FROM data WHERE email = '{email}' AND password = '{password}'";
                MySqlCommand command = new MySqlCommand(queryLogin, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    name = reader.GetString(1);
                    status = "succes";
                }
                else
                {
                    status = "gagal";
                }

            }
            catch (MySqlException ex)
            {
                status = "errormysql";
                sqlError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }



        // virtual lupaPassword untuk memproses data reset password dari database yang nantinya di kirim ke override
        public virtual void lupaPassword(string email)
        {
            string db = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            MySqlConnection connection = new MySqlConnection(db);
            try
            {
                connection.Open();
                queryLogin = $"SELECT * FROM data WHERE email = '{email}'";
                MySqlCommand command = new MySqlCommand(queryLogin, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    status = "succesreset";
                }
                else
                {
                    status = "gagalreset";
                }
            }
            catch (MySqlException ex)
            {
                status = "errormysql";
                sqlError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    class DataConnection : parentKantin
    {


        public override void daftar(string username, string email, string password)
        {
            // base.daftar berguna untuk memanggil method sebelumnya dan mengirimkan data username, email & Password untuk mengonfirmasi pendaftaran akun
            base.daftar(username, email, password);
            if (status == "tambahkan")
            {
                bool kondisiyt = true;
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write("╠═>");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Data Berhasil di tambahkan");
                Console.ResetColor();
                Thread.Sleep(500);
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Ingin lanjut ke menu login? y/t");
                Thread.Sleep(500);
                while (kondisiyt == true)
                {
                    Console.Write("╠═> Pilih: ");
                    var pilihan = Console.ReadLine().ToLower();
                    if (pilihan == "y")
                    {
                        kondisiyt = false;
                        program.login();
                    }
                    else if (pilihan == "t")
                    {
                        kondisiyt = false;
                        Thread.Sleep(500);
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.WriteLine("╠═> Anda Telah Keluar Program!");
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.Write("╠═>");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Maaf inputan yang anda input tidak ada!");
                        Console.ResetColor();
                    }
                }
            }
            else if (status == "gagalTambahkan")
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write("╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Maaf Akun Gagal Di buat, Mohon coba lagi nanti!");
                Console.ResetColor();
                System.Environment.Exit(1);
            }
            else if (status == "errormysql")
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Error: " + sqlError);
                Console.ReadKey();
                System.Environment.Exit(0);
            }
        }

        // override login menampilkan data dari database ke client
        public override void login(string email, string password)
        {
            // base.login berguna untuk memanggil method sebelumnya dan mengirimkan data email & password untuk mengonfirmasi login
            base.login(email, password);
            Console.WriteLine($"║");
            Console.WriteLine("╠═> Loading Login...");
            Thread.Sleep(1100);
            if (status == "succes")
            {
                Console.WriteLine($"║");
                Console.Write("╠═>");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Succes Login");
                Console.ResetColor();
                Thread.Sleep(900);
                Console.WriteLine($"║");
                Console.Write($"╠═> Halo Selamat Datang ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(name);
                Console.ResetColor();

                System.Threading.Thread.Sleep(1100);
                menuKantin menu = new menuKantin();
                menu.AddLogin(email, password);

            }
            else if (status == "gagal")
            {
                bool kondisiyt = true;
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Gagal Login. Mohon Masukan Email Dan Password Yang Valid!!!");
                Console.ResetColor();
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Apakah anda ingin tetap login akun? y/t");
                Thread.Sleep(500);
                while (kondisiyt == true)
                {
                    Console.Write("╠═> Pilih: ");
                    var pilihan = Console.ReadLine().ToLower();
                    if (pilihan == "y")
                    {
                        kondisiyt = false;
                        program.login();
                    }
                    else if (pilihan == "t")
                    {
                        kondisiyt = false;
                        Thread.Sleep(500);
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.WriteLine("╠═> Anda Telah Keluar Program!");
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.Write("╠═>");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Maaf inputan yang anda input tidak ada!");
                        Console.ResetColor();
                        Thread.Sleep(500);
                    }
                }

            }
            else if (status == "errormysql")
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            else
            {
                Console.Write(status);
            }
        }


        // override lupaPassword menampilkan data dari database ke client
        public override void lupaPassword(string email)
        {
            // base.lupaPassword berguna untuk memanggil method sebelumnya dan mengirimkan data email untuk me reset password
            base.lupaPassword(email);
            
            Console.WriteLine($"║");
            Thread.Sleep(500);
            Console.WriteLine("╠═> Loading Check Email...");
            Thread.Sleep(1100);
            if (status == "succesreset")
            {
                Console.WriteLine("║");
                Thread.Sleep(500);
                Console.Write("╠═>");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Email Berhasil Di Konfirmasi");
                Console.ResetColor();

                Console.WriteLine("║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Masukan Password Anda");
                Console.Write("╠═> New Pass: ");
                var resetPassword = Console.ReadLine();
                while (resetPassword.Length < 8)
                {
                    Console.WriteLine("║");
                    Thread.Sleep(500);
                    Console.Write("╠═>");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Maaf Password Harus Lebih Dari 8 Digit");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Console.Write("╠═> New Pass: ");
                    resetPassword = Console.ReadLine();
                }
                bool kondisiPassword = true;
                while (kondisiPassword == true)
                {
                        
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine("╠═> Masukan Ulang Password Anda");
                    Thread.Sleep(500);
                    Console.Write("╠═> New Pass: ");
                    var konPassword = Console.ReadLine();
                    if (resetPassword == konPassword)
                    {
                        kondisiPassword = false;
                        // update password
                        string db = "SERVER=localhost;DATABASE=csharplogin;UID=root;PASSWORD=;";
                        MySqlConnection connection = new MySqlConnection(db);
                        try
                        {
                            connection.Open();
                            string queryReset = $"UPDATE data SET password = '{konPassword}' WHERE email = '{email}' ";
                            MySqlCommand command = new MySqlCommand(queryReset, connection);

                            int tambahkan = command.ExecuteNonQuery();
                            if (tambahkan > 0)
                            {
                                Console.WriteLine("║");
                                Thread.Sleep(500);
                                Console.Write("╠═>");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" Password Berhasil Di Ubah");
                                Console.ResetColor();
                                Thread.Sleep(500);
                                Console.WriteLine("║");
                                Thread.Sleep(500);
                                Console.WriteLine("╠═> Ingin lanjut ke menu login? y/t");
                                Thread.Sleep(500);
                                bool kondisiyt = true;
                                while (kondisiyt == true)
                                {
                                    Console.Write("╠═> Pilih: ");
                                    var pilihan = Console.ReadLine().ToLower();
                                    if (pilihan == "y")
                                    {
                                        kondisiyt = false;
                                        program.login();
                                    }
                                    else if (pilihan == "t")
                                    {
                                        kondisiyt = false;
                                        Thread.Sleep(500);
                                        Console.WriteLine($"║");
                                        Thread.Sleep(500);
                                        Console.WriteLine("╠═> Anda Telah Keluar Program");
                                        System.Environment.Exit(0);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"║");
                                        Thread.Sleep(500);
                                        Console.Write("╠═>");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(" Maaf inputan yang anda input tidak ada!");
                                        Console.ResetColor();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("║");
                                Thread.Sleep(500);
                                Console.Write("╠═>");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Password Gagal Di Ubah");
                                Console.ResetColor();
                                //
                            }

                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine($"║");
                            Thread.Sleep(500);
                            Console.Write($"╠═>");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" Error: " + ex.Message);
                            Console.ResetColor();
                            Console.ReadKey();
                            System.Environment.Exit(0);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"║");
                        Thread.Sleep(500);
                        Console.Write("╠═>");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Maaf password yang anda masukan tidak sesuai dengan yang di atas!");
                        Console.ResetColor();
                    }
                }
            }
            else if (status == "gagalreset")
            {
                Thread.Sleep(500);
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write("╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Maaf email yang anda inputkan tidak ada!");
                Console.ResetColor();
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write("╠═> Enter Untuk Kembali Reset Password!");
                Console.ReadKey();
                program.lupaPassword();
            }
            else if (status == "errormysql")
            {
                    
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
        }
    }



    class menuKantin : parentKantin
    {

        // membuat list kosong dengan tipe string
        private List<string> loginData = new List<string>();

        // field untuk menyambungkan database
        private string server = "localhost";
        private string database = "csharplogin";
        private string uid = "root";
        private string pass = "";

        // variabel kosong untuk menampung data daru db
        private string email;
        private string username;
        private int saldo;

        // variabel untuk menampung makanan dan minuman
        private string jenisMakanan = "-";
        private string jenisMinuman = "-";
        private int hargaMakanan = 0;
        private int hargaMinuman = 0;
        private int totalmakanan = 0;
        private int totalminuman = 0;
        private int hargaAWAlminum = 0;
        private int hargaAWAlmakan = 0;

        bool BolMakanan = true;
        bool BolMinuman = true;


        // cuma menambahkan data ke list
        public void AddLogin(string email, string password)
        {
            loginData.Add(email);
            loginData.Add(password);
            menu();
        }


        public void menu()
        {
            string dbmenu = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            MySqlConnection connection = new MySqlConnection(dbmenu);
            try
            {
                connection.Open();
                string getInformasi = $"SELECT * FROM data WHERE email = '{loginData[0]}' AND password = '{loginData[1]}'";
                MySqlCommand command = new MySqlCommand(getInformasi, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    username = reader.GetString(1);
                    email = reader.GetString(2);
                    saldo = reader.GetInt32(4);
                }
                else
                {
                    Console.WriteLine($"║");
                    Console.WriteLine("╠═> Maaf User Tidak Terhubung Dengan Database!");
                    Console.WriteLine("╠═> Silahkan Login Ulang!");
                    System.Environment.Exit(1);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + ex.Message);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════ ");
            Console.WriteLine("║ INFORMASI AKUN                    ");
            Console.WriteLine($"║ Email : {email}                  ");
            Console.WriteLine($"║ Nama  : {username}               ");
            Console.WriteLine($"║ Saldo : {saldo}                  ");
            Console.WriteLine("╠══════════════════════════════════ ");
            Console.WriteLine("║         Menu PebriKantin          ");
            Console.WriteLine("╠══════════════════════════════════ ");
            Console.WriteLine("╠═[1]. Makanan                     ");
            Console.WriteLine("╠═[2]. Minuman                     ");
            Console.WriteLine("╠═[3]. Riwayat Pembayaran          ");
            Console.WriteLine("╠═[4]. Setting Akun & Isi Saldo    ");
            Console.WriteLine("╠══════════════════════════════════");
            Console.WriteLine($"║                                  ");
            Console.Write("╠═> Pilih: ");
            var pilihan = Console.ReadLine();
            if (pilihan == "1")
            {
                Makanan();
            }
            else if (pilihan == "2")
            {
                Minuman();
            }
            else if (pilihan == "3")
            {
                Console.Clear();
                checkRiwayat();
            }
            else if (pilihan == "4")
            {
                settingAccount();
            }
            else
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write("╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Maaf inputan yang anda input tidak ada!");
                Console.ResetColor();
                Thread.Sleep(500);
                menu();
            }
        }

        
        public void settingAccount()
        {
            bool kondisi = true;
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════ ");
            Console.WriteLine("║ Setting Akun                      ");
            Console.WriteLine($"║ Email : {email}                  ");
            Console.WriteLine($"║ Nama  : {username}               ");
            Console.WriteLine($"║ Saldo : {saldo}                  ");
            Console.WriteLine("╠══════════════════════════════════ ");
            Console.WriteLine($"╠═[1]. Ganti Email                 ");
            Console.WriteLine($"╠═[2]. Ganti Username              ");
            Console.WriteLine($"╠═[3]. Isi Saldo                   ");
            Console.WriteLine($"╠═[4]. Kembali Ke Menu Utama       ");
            Console.WriteLine($"╠═[5]. Logout Akun                 ");
            Console.WriteLine($"║                                  ");
            while(kondisi == true)
            {
                Console.Write("╠═> Pilih: ");
                var pilih = Console.ReadLine();
                if (pilih == "1")
                {
                    kondisi = false;
                    gantiEmail();
                }
                else if (pilih == "2")
                {
                    kondisi = false;
                    gantiUser();
                }
                else if (pilih == "3")
                {
                    kondisi = false;
                    Console.WriteLine($"║");
                    isiSaldo();
                }
                else if (pilih == "4")
                {
                    kondisi = false;
                    menu();
                }
                else if (pilih == "5")
                {
                    kondisi = false;
                    Console.WriteLine("╠═> Anda Telah Logout ");
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.Write("╠═>");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Maaf inputan yang anda input tidak ada!");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                }
            }
        }

        public void gantiEmail()
        {
            // update password
            string db = "SERVER=localhost;DATABASE=csharplogin;UID=root;PASSWORD=;";
            MySqlConnection connection = new MySqlConnection(db);
            try
            {
                connection.Open();
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Masukan Email Baru Anda!");
                Console.Write("╠═> Email: ");
                string gantiEmail = Console.ReadLine();
                string queryUpdate = $"UPDATE data SET email = '{gantiEmail}' WHERE email = '{email}'";
                MySqlCommand command = new MySqlCommand(queryUpdate, connection);

                int tambahkan = command.ExecuteNonQuery();
                if (tambahkan > 0)
                {
                    loginData[0] = gantiEmail;
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine("╠═> Email Berhasil Di Ubah");
                    Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                    Console.ReadKey();
                    Thread.Sleep(100);
                    menu();
                }
                else
                {
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine("╠═> Email Gagal Di Ubah");
                    Console.Write("╠═> Enter Untuk Kembali Ke Menu Setting");
                    Console.ReadKey();
                    Thread.Sleep(100);
                    menu();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }
        }

        public void gantiUser()
        {
            // update password
            string db = "SERVER=localhost;DATABASE=csharplogin;UID=root;PASSWORD=;";
            MySqlConnection connection = new MySqlConnection(db);
            try
            {
                connection.Open();
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.WriteLine("╠═> Masukan Nama Baru Anda");
                Console.Write("╠═> Nama: ");
                string nama = Console.ReadLine();
                string queryUpdate = $"UPDATE data SET username = '{nama}' WHERE email = '{email}'";
                MySqlCommand command = new MySqlCommand(queryUpdate, connection);

                int tambahkan = command.ExecuteNonQuery();
                if (tambahkan > 0)
                {
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine("╠═> Username Berhasil Di Ubah");
                    Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                    Console.ReadKey();
                    Thread.Sleep(100);
                    menu();
                }
                else
                {
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine("╠═> Username Gagal Di Ubah");
                    Console.Write("╠═> Enter Untuk Kembali Ke Menu Setting");
                    Console.ReadKey();
                    Thread.Sleep(100);
                    menu();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }
        }

        public void isiSaldo()
        {
            // update saldo
            int hargaMakanan;
            string db = "SERVER=localhost;DATABASE=csharplogin;UID=root;PASSWORD=;";
            MySqlConnection connection = new MySqlConnection(db);
            try
            {
                connection.Open();
                Thread.Sleep(500);
                Console.WriteLine($"╠═> Masukan Nominal Saldo");
                Console.Write("╠═> Saldo: ");
                int saldoSekarang = int.Parse(Console.ReadLine());
                int totalSaldo = saldo + saldoSekarang;
                string queryUpdate = $"UPDATE data SET saldo = '{totalSaldo}' WHERE email = '{email}'";
                MySqlCommand command = new MySqlCommand(queryUpdate, connection);

                int tambahkan = command.ExecuteNonQuery();
                if (tambahkan > 0)
                {
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine($"╠═> Saldo Berhasil Di Tambahkan");
                    Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                    Console.ReadKey();
                    Thread.Sleep(100);
                    menu();
                }
                else
                {
                    Console.WriteLine($"║");
                    Thread.Sleep(500);
                    Console.WriteLine($"╠═> Saldo Gagal Di Tambahkan");
                    Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                    Console.ReadKey();
                    Thread.Sleep(100);
                    menu();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }
        }



        // makanan minuman
        public void Makanan()
        {
            BolMakanan = false;
            string dbmenu = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            MySqlConnection connection = new MySqlConnection(dbmenu);
            try
            {
                connection.Open();
                string queryMkanan = $"SELECT * FROM makanan";
                MySqlCommand command = new MySqlCommand(queryMkanan, connection);
                MySqlDataReader reader = command.ExecuteReader();
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║       Makanan Yang Tersedia           ║");
                Console.WriteLine("╠═══════════════════════════════════════╝");
                Console.WriteLine("║");
                while(reader.Read())
                {
                    Console.WriteLine($"╠═[{reader.GetInt32(0)}]. {reader.GetString(1)} - Rp. {reader.GetInt32(2)}");
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }

            // check data di database
            Console.WriteLine("║");
            Console.Write("╠═> Pilih: ");
            var pilih = Console.ReadLine();
            try
            {
                connection.Open();
                string queryMkanan = $"SELECT * FROM makanan WHERE id = '{pilih}'";
                MySqlCommand command = new MySqlCommand(queryMkanan, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    hargaAWAlmakan = reader.GetInt16(2);
                    hargaMakanan = reader.GetInt32(2);
                    jenisMakanan = reader.GetString(1);
                    Console.WriteLine("║");
                    Console.WriteLine("╠═> Masukan Berapa Banyak Makanan Yang Ingin Di Pesan ");
                    Console.Write("╠═> Berapa: ");
                    totalmakanan = int.Parse(Console.ReadLine());
                    hargaMakanan *= totalmakanan;
                    if(BolMinuman == true)
                    {
                        Console.WriteLine("║");
                        Console.WriteLine("╠═> Apakah Anda Ingin Pesan Minum? y/t ");
                        bool pil = true;

                        while (pil == true)
                        {
                            Console.Write("╠═> Pilih: ");
                            var pilihan = Console.ReadLine().ToLower();
                            if (pilihan == "y")
                            {
                                pil = false;
                                Minuman();
                            }
                            else if (pilihan == "t")
                            {
                                pil = false;
                                checkout();
                            }
                            else
                            {
                                pil = true;
                                Console.WriteLine("║");
                                Console.Write("╠═> Maaf Pilihan Tidak Ada\n");
                            }
                        }
                    }
                    else
                    {
                        Thread.Sleep(700);
                        checkout();
                    }
                }
                else
                {
                    Console.WriteLine("║");
                    Console.WriteLine("╠═> Maaf Makanan Tidak Tersedia!");
                    Thread.Sleep(500);
                    Makanan();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }

        }


        // makanan minuman
        public void Minuman()
        {
            BolMinuman = false;
            string dbmenu = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            MySqlConnection connection = new MySqlConnection(dbmenu);
            try
            {
                connection.Open();
                string queryMkanan = $"SELECT * FROM minuman";
                MySqlCommand command = new MySqlCommand(queryMkanan, connection);
                MySqlDataReader reader = command.ExecuteReader();
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║       Minuman Yang Tersedia           ║");
                Console.WriteLine("╠═══════════════════════════════════════╝");
                Console.WriteLine("║");
                while (reader.Read())
                {
                    Console.WriteLine($"╠═[{reader.GetInt32(0)}]. {reader.GetString(1)} - Rp. {reader.GetInt32(2)}");
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }

            // check data di database
            Console.WriteLine("║");
            Console.Write("╠═> Pilih: ");
            var pilih = Console.ReadLine();
            try
            {
                connection.Open();
                string queryMinuman = $"SELECT * FROM minuman WHERE id = '{pilih}'";
                MySqlCommand command = new MySqlCommand(queryMinuman, connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    hargaAWAlminum = reader.GetInt16(2);
                    hargaMinuman = reader.GetInt32(2);
                    jenisMinuman = reader.GetString(1);
                    Console.WriteLine("║");
                    Console.WriteLine("╠═> Masukan Berapa Banyak Minuman Yang Ingin Di Pesan ");
                    Console.Write("╠═> Berapa: ");
                    totalminuman = int.Parse(Console.ReadLine());
                    hargaMinuman *= totalminuman;
                    if(BolMakanan == true)
                    {
                        Console.WriteLine("║");
                        Console.WriteLine("╠═> Apakah Anda Ingin Pesan Makan? y/t ");
                        bool pil = true;

                        while (pil == true)
                        {
                            Console.Write("╠═> Pilih: ");
                            var pilihan = Console.ReadLine().ToLower();
                            if (pilihan == "y")
                            {
                                pil = false;
                                Makanan();
                            }
                            else if (pilihan == "t")
                            {
                                pil = false;
                                checkout();
                            }
                            else
                            {
                                pil = true;
                                Console.WriteLine("║");
                                Console.Write("╠═> Maaf Pilihan Tidak Ada\n");
                            }
                        }
                    }
                    else
                    {
                        Thread.Sleep(700);
                        checkout();
                    }
                }
                else
                {
                    Console.WriteLine("║");
                    Console.WriteLine("╠═> Maaf Minuman Tidak Tersedia!");
                    Thread.Sleep(500);
                    Minuman();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + sqlError);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            finally
            {
                connection.Close();
            }

        }

        public void checkout()
        {
            string dbmenu = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={pass};";
            MySqlConnection connection = new MySqlConnection(dbmenu);
            int pembayaran = hargaMakanan + hargaMinuman;
            int sisa = saldo - pembayaran;
            Console.WriteLine("║");
            Console.WriteLine("╠═══════════════════════════════════════╗");
            Console.WriteLine("║          STRUCK PEMBELIAN             ║");
            Console.WriteLine("╠═══════════════════════════════════════╝");
            Console.WriteLine("║ NAMA PEMBELI  : " + username);
            Console.WriteLine("╠════════════════════════════════════════");
            Console.WriteLine("║ NAMA MAKANAN  : " + jenisMakanan);
            Console.WriteLine("║ TOTAL PESANAN : " + totalmakanan);
            Console.WriteLine("║ HARGA AWAL    : " + hargaAWAlmakan);
            Console.WriteLine("║ TOTAL HARGA   : " + hargaMakanan);
            Console.WriteLine("╠════════════════════════════════════════");
            Console.WriteLine("║ NAMA MINUMAN  : " + jenisMinuman);
            Console.WriteLine("║ TOTAL PESANAN : " + totalminuman);
            Console.WriteLine("║ HARGA AWAL    : " + hargaAWAlminum);
            Console.WriteLine("║ TOTAL HARGA   : " + hargaMinuman);
            Console.WriteLine("╠════════════════════════════════════════");
            Console.WriteLine("║ PEMBAYARAN    : " + pembayaran);
            Console.WriteLine("║ SALDO USER    : " + saldo);
            Console.WriteLine("║ KEMBALIAN     : -");
            Console.WriteLine("╠════════════════════════════════════════");
            Console.WriteLine("║");
            Console.WriteLine("╠═> Apakah Anda Ingin Melanjut Pembayaran? y/t");
            bool kondisiPembayaran = true;
            while(kondisiPembayaran == true)
            {

                Console.Write("╠═> Pilih: ");
                var pilih = Console.ReadLine().ToLower();
                if(pilih == "y")
                {
                    kondisiPembayaran = false;
                    if(pembayaran <= saldo )
                    {
                        try
                        {
                            // Console.WriteLine("╠═> Mohon Tunggu Sebentar Karna Program Sedang Update Saldo Ke Database!");
                            connection.Open();
                            MySqlCommand command = new MySqlCommand($"UPDATE data SET saldo = '{sisa}' WHERE email = '{email}'", connection);
                            int rows = command.ExecuteNonQuery();
                            if(rows > 0)
                            {
                                // Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                                Thread.Sleep(500);
                                Console.Clear();
                                Console.WriteLine("╔═══════════════════════════════════════╗");
                                Console.WriteLine("║          STRUCK PEMBELIAN             ║");
                                Console.WriteLine("╠═══════════════════════════════════════╝");
                                Console.WriteLine("║ NAMA PEMBELI  : " + username);
                                Console.WriteLine("╠═══════════════════════════════════════");
                                Console.WriteLine("║ NAMA MAKANAN  : " + jenisMakanan);
                                Console.WriteLine("║ TOTAL PESANAN : " + totalmakanan);
                                Console.WriteLine("║ HARGA AWAL    : " + hargaAWAlmakan);
                                Console.WriteLine("║ TOTAL HARGA   : " + hargaMakanan);
                                Console.WriteLine("╠════════════════════════════════════════");
                                Console.WriteLine("║ NAMA MINUMAN  : " + jenisMinuman);
                                Console.WriteLine("║ TOTAL PESANAN : " + totalminuman);
                                Console.WriteLine("║ HARGA AWAL    : " + hargaAWAlminum);
                                Console.WriteLine("║ TOTAL HARGA   : " + hargaMinuman);
                                Console.WriteLine("╠════════════════════════════════════════");
                                Console.WriteLine("║ PEMBAYARAN    : " + pembayaran);
                                Console.WriteLine("║ SALDO USER    : " + saldo);
                                Console.WriteLine("║ KEMBALIAN     : " + sisa);
                                Console.WriteLine("╠════════════════════════════════════════");
                                Console.WriteLine("║");
                                simpanRiwayat(pembayaran, sisa);
                                Console.WriteLine("\n╠═> Apakah Anda Ingin Bertransksi Lagi? y/t");
                                bool kondisiyt = true;
                                while (kondisiyt == true)
                                {

                                    Console.Write("╠═> Pilih: ");
                                    var pilihyt = Console.ReadLine().ToLower();
                                    if (pilihyt == "y")
                                    {
                                        kondisiyt = false;
                                        menu();
                                    }
                                    else if (pilihyt == "t")
                                    {
                                        kondisiyt = false;
                                        Console.WriteLine("║");
                                        Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                                        Console.ReadKey();
                                        menu();
                                    }
                                    else
                                    {
                                        Console.WriteLine("║");
                                        kondisiyt = true;
                                        Console.WriteLine("╠═> Maaf Pilihan Tidak Ada!");
                                        Console.WriteLine("║");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("║");
                                Console.WriteLine("╠═> Maaf Transaksi Gagal!");
                                Thread.Sleep(400);
                                Console.WriteLine("╠═> Anda Otomatis Di Keluarkan Dari Program");
                                System.Environment.Exit(0);

                            }
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine("║");
                            Thread.Sleep(500);
                            Console.Write($"╠═>");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" Error: " + ex.Message);
                            Console.ResetColor();
                            Console.ReadKey();
                            System.Environment.Exit(0);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                    else
                    {

                        Console.WriteLine("║");
                        Thread.Sleep(700);
                        Console.Write($"╠═>");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" Maaf Saldo Anda Tidak Cukup Untuk Melanjutkan Transaksi\n");
                        Console.ResetColor();
                        Console.WriteLine("║");
                        Thread.Sleep(500);
                        Console.WriteLine("╠═> Apakah Anda Ingin Isi Saldo? y/t");
                        bool kondisiyt = true;
                        while (kondisiyt == true)
                        {

                            Console.Write("╠═> Pilih: ");
                            var pilihyt = Console.ReadLine().ToLower();
                            if (pilihyt == "y")
                            {
                                kondisiyt = false;
                                Console.Clear();
                                isiSaldo();
                            }
                            else if (pilihyt == "t")
                            {
                                kondisiyt = false;
                                Console.WriteLine("║");
                                Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                                Console.ReadKey();
                                menu();
                            }
                            else
                            {
                                Console.WriteLine("║");
                                kondisiyt = true;
                                Console.WriteLine("╠═> Maaf Pilihan Tidak Ada!");
                                Console.WriteLine("║");
                            }
                        }
                    }
                    

                }
                else if (pilih == "t")
                {
                    kondisiPembayaran = false;
                    Console.WriteLine("║");
                    Console.Write("╠═> Enter Untuk Kembali Ke Menu Utama!");
                    Console.ReadKey();
                    menu();
                }
                else
                {
                    Console.WriteLine("║");
                    kondisiPembayaran = true;
                    Console.WriteLine("╠═> Maaf Pilihan Tidak Ada!");
                    Console.WriteLine("║");
                }
            }
        }

        public void simpanRiwayat(int bayar, int sisa)
        {
            string db = $"SERVER={server};DATABASE=csharplogin;UID={uid};PASSWORD={pass};";
            try
            {
                MySqlConnection connection = new MySqlConnection(db);
                connection.Open();
                string queryCheck = $"SELECT * FROM riwayat";
                MySqlCommand command = new MySqlCommand(queryCheck, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cetakidOtomatis = reader.GetInt32(0);
                    cetakidOtomatis += 1;
                }
                reader.Close();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + ex.Message);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }

            try
            {
                MySqlConnection connection = new MySqlConnection(db);
                connection.Open();
                DateTime hari_ini = DateTime.Now;
                string hari = hari_ini.ToString("D");
                string querysimpanriwayat = $"INSERT INTO riwayat (id, tanggal, Pembeli, namaMakan, totalMakan, hargaAwalMakan, totalHargaMakan, namaMinum, totalMinum, hargaAwalMinum, totalHargaMinum, pembayaran, saldo, kembalian) VALUES ('{cetakidOtomatis}','{hari}', '{username}','{jenisMakanan}','{totalmakanan}','{hargaAWAlmakan}','{hargaMakanan}','{jenisMinuman}','{totalminuman}','{hargaAWAlminum}','{hargaMinuman}','{bayar}','{saldo}','{sisa}')";
                MySqlCommand command = new MySqlCommand(querysimpanriwayat, connection);
                int tambahkan = command.ExecuteNonQuery();
                if (tambahkan > 0) 
                { 
                    Thread.Sleep(1000);
                    Console.WriteLine("╠═> Sedang Menyimpan Riwayat Transaksi");
                    Thread.Sleep(400);
                    Console.Write($"╠═>");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" Berhasil Simpan Riwayat Transaksi ");
                    Thread.Sleep(400);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("║");
                    Console.Write($"╠═>");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" Maaf Gagal Menyimpan Riwayat Transaksi ");
                    Console.ResetColor();
                    Thread.Sleep(400);
                    Console.WriteLine("╠═> Anda Otomatis Di Keluarkan Dari Program");
                    System.Environment.Exit(0);
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + ex.Message);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            
        }

        public void checkRiwayat()
        {
            string db = $"SERVER={server};DATABASE=csharplogin;UID={uid};PASSWORD={pass};";

            try
            {
                MySqlConnection connection = new MySqlConnection(db);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM riwayat", connection);
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║          RIWAYAT TRANSAKSI            ║");
                Console.WriteLine("╠═══════════════════════════════════════╝");
                Console.WriteLine("║ ");
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Console.WriteLine("╠═> TANGGAL TRANSAKSI : " + reader.GetString(1));
                        Console.WriteLine("╠═> NAMA PEMBELI      : " + reader.GetString(2));
                        Console.WriteLine("╠═> NAMA MAKANAN      : " + reader.GetString(3));
                        Console.WriteLine("╠═> TOTAL PESANAN     : " + reader.GetInt32(4));
                        Console.WriteLine("╠═> HARGA AWAL        : " + reader.GetInt32(5));
                        Console.WriteLine("╠═> TOTAL HARGA       : " + reader.GetInt32(6));
                        Console.WriteLine("╠═> NAMA MINUMAN      : " + reader.GetString(7));
                        Console.WriteLine("╠═> TOTAL PESANAN     : " + reader.GetInt32(8));
                        Console.WriteLine("╠═> HARGA AWAL        : " + reader.GetInt32(9));
                        Console.WriteLine("╠═> TOTAL HARGA       : " + reader.GetInt32(10));
                        Console.WriteLine("╠═> PEMBAYARAN        : " + reader.GetInt32(11));
                        Console.WriteLine("╠═> SALDO USER        : " + reader.GetInt32(12));
                        Console.WriteLine("╠═> KEMBALIAN         : " + reader.GetInt32(13));
                        Console.WriteLine("╠═══════════════════════════════════════=");
                        Console.WriteLine("║ ");
                    }
                }
                else
                {
                    Console.WriteLine("╠═> Tidak Ada Riwayat Transaksi");
                    Console.Write("╠═> Enter Untuk Kembali!");
                    Console.ReadKey();
                }
                Console.WriteLine("║ ");
                Console.Write("╠═> Enter Untuk Kembali!");
                Console.ReadKey();
                menu();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("║");
                Thread.Sleep(500);
                Console.Write($"╠═>");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" Error: " + ex.Message);
                Console.ResetColor();
                Console.ReadKey();
                System.Environment.Exit(0);
            }

        }
    }
}

