using Odev;
bool Evet;
do
{
    Console.WriteLine("Kaan Cörüt - Ödev");
    Console.WriteLine("İşlem yapmak istediğiniz depolama tipini seçiniz...");
    Console.WriteLine("S - SQL işlemi | T - Text işlemi ->>");
    char Secim = char.ToUpper(Convert.ToChar(Console.Read()));

    bool sql = Secim.Equals(Convert.ToChar("S"));
    bool text = Secim.Equals(Convert.ToChar("T"));

    bool bitir = true;
    while (bitir)
    {
        if (!sql && !text )
        {
            Console.WriteLine("Bilinmeyen bir Seçim yaptınız...");
            Console.ReadLine();
            Console.WriteLine("S - SQL işlemi | T - Text işlemi ->>");
            Secim = char.ToUpper(Convert.ToChar(Console.Read()));
            sql = Secim.Equals(Convert.ToChar("S"));
            text = Secim.Equals(Convert.ToChar("T"));
        }
        else
            bitir = false;
    }
    Console.WriteLine("Yapmak İstediğiniz İşlemi Seçiniz>>");
    Console.ReadLine();
    Console.WriteLine("E - Yeni Kayıt ekle | L - Tüm Kayıtları Getir | A - Kayıt Ara ->>");

    Secim = char.ToUpper(Convert.ToChar(Console.Read()));
    bool Ekle = Secim.Equals(Convert.ToChar("E"));
    bool Liste = Secim.Equals(Convert.ToChar("L"));
    bool Ara = Secim.Equals(Convert.ToChar("A"));

    bitir = true;
    while (bitir)
    {
        if (!Ekle && !Liste && !Ara)
        {
            Console.WriteLine("Bilinmeyen bir Seçim yaptınız...");
            Console.ReadLine();
            Console.WriteLine("E - Yeni Kayıt ekle | L - Tüm Kayıtları Getir | A - Kayıt Ara ->>");
            Secim = char.ToUpper(Convert.ToChar(Console.Read()));
            Ekle = Secim.Equals(Convert.ToChar("E"));
            Liste = Secim.Equals(Convert.ToChar("L"));
            Ara = Secim.Equals(Convert.ToChar("A"));
        }
        else
            bitir = false;
    }
    Manager manager;
    if (sql)
    {
        VeritabaniKontrol vtk = new VeritabaniKontrol();
        Veritabani vt = new Veritabani();
        manager = new Manager(vt);
    }
    else  
    {
        TextFile tf = new TextFile();
        manager = new Manager(tf);
    }
    Console.Clear();
    if (Ekle)
    {
        Kitap ekleKitap = new Kitap();
        if (text)
        {
            Console.Write("Kitabın ID'sini giriniz ->> " + "\n");
            Console.ReadLine();
            Console.WriteLine("");
            int id;
            //ekleKitap.KitapID = Convert.ToInt32(Console.ReadLine());
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Yanlış bir Seçim yaptınız Sadece Sayı giriniz: ");
            }
            ekleKitap.KitapID = id;
        }
        Console.Write("Kitabın Adını giriniz ->> ");
        if (sql)
        {
            Console.ReadLine();
            Console.WriteLine("");
        }
        ekleKitap.Ad = Console.ReadLine();
        Console.Write("Kitabın Yazarını giriniz ->> ");
        ekleKitap.YazarAd = Console.ReadLine();
        Console.Write("Kitabın Fiyatını giriniz ->> ");
        double fiyat;
        //ekleKitap.Fiyat = Convert.ToDouble(Console.ReadLine());
        while (!Double.TryParse(Console.ReadLine(), out fiyat))
        {
            Console.WriteLine("Yanlış bir Seçim yaptınız Sadece Sayı giriniz: ");
        }
        ekleKitap.Fiyat = fiyat;

        manager.Ekle(ekleKitap);
    }
    else if (Liste) 
    {
        Yazdir.yazdir(manager.Listele());
    }
    else if (Ara) 
    {
        Console.WriteLine("Aranacak Kitabın ID'sini giriniz ->> ");
        Console.ReadLine();
        Console.WriteLine("");
        int id;
        //ekleKitap.KitapID = Convert.ToInt32(Console.ReadLine());
        while (!Int32.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Yanlış bir Seçim yaptınız Sadece Sayı giriniz: ");
        }
        Yazdir.yazdir(manager.Bul(id));
    }

    Console.WriteLine("Başka bir işlem yapmak istiyor musnuz?");
    if(Liste)
        Console.ReadLine();
    Console.WriteLine("E - Evet | H - Hayır");
    Secim = char.ToUpper(Convert.ToChar(Console.Read()));
    Evet = Secim.Equals(Convert.ToChar("E"));
    if (Evet)
    {
        Console.Clear();
        Console.ReadLine();  
    }

} while (Evet);