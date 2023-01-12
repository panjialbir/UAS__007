using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS__007
{
    class Node
    {
        public string nama;
        public int id_plnggn;
        public string jenis_kelamin;
        public int no_hp;
        public Node next;
        public Node prev;
    }
    class DoubleLinked
    {
        Node START;

        public DoubleLinked()
        {
            START = null;
        }
        public void addNode()
        {
            int id_plnggn;
            string nama;
            string jenis_kelamin;
            int no_hp;
            Console.Write("\nMasukkan Id Pelanggan: ");
            id_plnggn = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Pelanggan: ");
            nama = (Console.ReadLine());
            Console.Write("\nMasukkan Jenis Kelamin Pelanggan: ");
            jenis_kelamin = (Console.ReadLine());
            Console.Write("\nMasukkan Nomer Telepon Pelanggan: ");
            no_hp = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.id_plnggn = id_plnggn;
            newnode.nama = nama;
            newnode.jenis_kelamin = jenis_kelamin;
            newnode.no_hp = no_hp;

            if (START == null || id_plnggn <= START.id_plnggn)
            {
                if ((START != null) && (id_plnggn == START.id_plnggn))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                id_plnggn >= current.id_plnggn; previous = current, current =
                current.next)
            {
                if (id_plnggn == current.id_plnggn)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        public bool Search(int id_plnggn, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                id_plnggn != current.id_plnggn; previous = current,
                current = current.next) { }
            return (current != null);
        }
        public bool delNode(int id_plnggn)
        {
            Node previous, current;
            previous = current = null;
            if (Search(id_plnggn, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }

            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nLoh Kosong");
            else
            {
                Console.WriteLine("\nNih " +
                    "Datanya : \n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.id_plnggn + " " + currentNode.nama + " " + currentNode.jenis_kelamin + " " + currentNode.no_hp + "\n");
            }
        }
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nLoh Kosong");
            else
            {
                Console.WriteLine("\nNih " +
                    "Datanya : \n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next) { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.id_plnggn + " " + currentNode.nama + " " + currentNode.jenis_kelamin + " " + currentNode.no_hp + "\n");
                    currentNode = currentNode.prev;
                }

            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            DoubleLinked obj = new DoubleLinked();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Masukkan Data Pelanggan" +
                        "\n 2. Hapus Data" +
                        "\n 3. Tampilkan Data" +
                        "\n 4. Tampilkan Semua Data" +
                        "\n 5. Cari Data" +
                        "\n 6. Exit \n" +
                        "\n Enter your choice (1 - 6):");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.WriteLine("Masukkan Id Pelanggan");
                                Console.WriteLine("Masukkan Nama Pelanggan");
                                Console.WriteLine("Masukkan Jenis Kelamin Pelanggan");
                                Console.WriteLine("Masukkan Nomer Telepon Pelanggan");


                                obj.addNode();

                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nLoh kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan id pelanggan yang mau dihapus" +
                                    ":");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Tidak Ketemu");
                                else
                                    Console.WriteLine("Data" + rollNo + "sudah terhapus \n");

                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                obj.revtraverse();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Masukkan Id Pelanggan Yang Akan Dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nTidak Ditemukan ");
                                else
                                {
                                    Console.WriteLine("\nNah Ketemu");
                                    Console.WriteLine("\nId plnggn: " + curr.id_plnggn);
                                    Console.WriteLine("\nnama: " + curr.nama);
                                    Console.WriteLine("\njenis kelamin: " + curr.jenis_kelamin);
                                    Console.WriteLine("\nno telepon: " + curr.no_hp);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}
////2. algoritma yang saya gunakan ialah doublelinked list. Karena setelah saya lihat lihat, hanya doublelinkedlist yang cocok
///3. Front dan Rear
///4. kalau array itu seperti sel sel menyamping, dan linked itu menurun kebawah
///5. a. siblingnya yaitu 5. 12, 16, 18,25, 28, 30,32
///   b. Inorder yaitu Data tsb dimulai dari sebelah prorioritas kiri dulu lalu dilanjuti dengan data disebelah kanan dari induk itu sendiri



