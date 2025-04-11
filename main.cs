using System;

public class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }

    public virtual void TampilkanInfo()
    {
        Console.WriteLine("Nama       : " + nama);
        Console.WriteLine("ID         : " + id);
        Console.WriteLine("Gaji Pokok : " + gajiPokok);
        Console.WriteLine("Gaji Akhir : " + HitungGaji());
    }
}

public class KaryawanTetap : Karyawan
{
    private double bonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok + bonusTetap;
    }
}

public class KaryawanKontrak : Karyawan
{
    private  double potonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok - potonganKontrak;
    }
}

public class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Sistem Manajemen Karyawan ===");
        Console.Write("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
        string jenis = Console.ReadLine().ToLower();

        Console.Write("Nama       : ");
        string nama = Console.ReadLine();
        Console.Write("ID         : ");
        string id = Console.ReadLine();
        Console.Write("Gaji Pokok : ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        switch (jenis)
        {
            case "tetap":
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                break;
            case "magang":
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
        }

        Console.WriteLine("\n=== Informasi Karyawan ===");
        karyawan.TampilkanInfo();
    }
}
