using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    abstract class MusicalInstruments
    {
        public string brand { get; set; }
        public string origin { get; set; }
        public string userInterface { get; set; }
        public string range { get; set; }
        public bool modern { get; set; }
        public float length { get; set; }
        public float weight { get; set; }
        public float price { get; set; }
        public int age { get; set; }
        public double volume { get; set; }
        public abstract void GetInfo();
        public abstract void BrandSticker();
    }
    // Струнные инструменты.
    class Stringed : MusicalInstruments
    {
        public string deckMaterial;
        public string stringMaterial;
        public Stringed()
        {
            userInterface = "strings";
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Material of the deck: {deckMaterial}, material of {userInterface}: {stringMaterial}.");
        }
        public override void BrandSticker()
        {
            Console.WriteLine("The {0} {1} was made in {2}.", GetType().Name, brand, origin);
        }
    }
    // Духовые инструменты.
    class Brass : MusicalInstruments
    {
        public string family;
        public string material;
        public override void GetInfo()
        {
            Console.WriteLine($"Material of the instrument: {material}.");
        }
        public override void BrandSticker()
        {
            Console.WriteLine("The {4} {3} {0} {1} was made in {2}.", GetType().Name, brand, origin, range, family);
        }
    }
    // Клавишные инструменты.
    class Keyboard : MusicalInstruments
    {
        public string keyboardType;
        public string caseMaterial;
        public Keyboard()
        {
            userInterface = "keyboard";
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Type of the keyboard: {keyboardType}, material of the {GetType().Name}: {caseMaterial}.");
        }
        public override void BrandSticker()
        {
            Console.WriteLine("The {0} {1} was made in {2}.", GetType().Name, brand, origin);
        }
    }
    // Фортепиано. 
    class Piano : Keyboard
    {
        public Piano(string keyboardType, string caseMaterial, string brand, string origin, int price)
        {
            this.keyboardType = keyboardType;
            this.caseMaterial = caseMaterial;
            this.brand = brand;
            this.origin = origin;
            this.price = price;
        }
    }
    // Тромброн.
    class Trombone : Brass
    {
        public Trombone(string family, string brand, string origin, string range, int price)
        {
            material = "Brass";
            this.family = family;
            this.brand = brand;
            this.origin = origin;
            this.range = range;
            this.price = price;
        }
    }
    // Диджериду.
    class Didgeridoo : Brass
    {
        public Didgeridoo(string family, string brand, string origin, string range, string material, int price)
        {
            this.material = material;
            this.family = family;
            this.brand = brand;
            this.origin = origin;
            this.range = range;
            this.price = price;
        }
        public Didgeridoo(string family, string brand, string origin, string range, int price) : this(family, brand, origin, range, "wood", price)
        {
            this.family = family;
            this.brand = brand;
            this.origin = origin;
            this.range = range;
            this.price = price;
        }
    }
    // Скрипка.
    class Viola : Stringed
    {
        public Viola(string deckMaterial, string stringMaterial, string brand, string origin, int price)
        {
            this.deckMaterial = deckMaterial;
            this.stringMaterial = stringMaterial;
            this.brand = brand;
            this.origin = origin;
            this.price = price;
        }
        public Viola(string brand, string origin, int price) : this("wood", "cooper", brand, origin, price)
        {
            this.brand = brand;
            this.origin = origin;
            this.price = price;
        }
    }
    // Гитара.
    class Guitar : Stringed
    {
        public string typeOfGuitar;
        public Guitar(string deckMaterial, string stringMaterial, string typeOfGuitar, string brand, string origin, int price)
        {
            this.typeOfGuitar = typeOfGuitar;
            this.deckMaterial = deckMaterial;
            this.stringMaterial = stringMaterial;
            this.brand = brand;
            this.origin = origin;
            this.price = price;
        }
        public Guitar(string brand, string origin, int price) : this("acoustic", "wood", "cooper", brand, origin, price)
        {
            this.brand = brand;
            this.origin = origin;
            this.price = price;
        }
        public override void BrandSticker()
        {
            Console.WriteLine("The {3} {0} {1} was made in {2}.", GetType().Name, brand, origin, typeOfGuitar);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Viola Brahner_bvc_370 = new Viola("plastic", "iron", "Brahner", "China", 4234);

            Viola Random666 = new Viola("VioFromAli", "New Zealand", 666);

            Guitar Yamaha_Pacifica_012_BL = new Guitar("wood", "iron", "electric", "Yamaha", "Japan", 34233);

            Trombone Roy_Benson_BT_260 = new Trombone("slide", "Roy_Benson", "Germany", "Baritone", 95434);

            Didgeridoo Yuka_DDP51_4 = new Didgeridoo("natural", "Yuka", "France", "tenor", "plastic", 4666);

            Piano Roland_PHA_4 = new Piano("hammer action", "composite", "Roland", "Japan", 23433);

            List<MusicalInstruments> collection = new List<MusicalInstruments>();
            collection.Add(Brahner_bvc_370);
            collection.Add(Random666);
            collection.Add(Yamaha_Pacifica_012_BL);
            collection.Add(Roy_Benson_BT_260);
            collection.Add(Yuka_DDP51_4);
            collection.Add(Roland_PHA_4);
            // Сортировка по возрастанию цены.
            var sorted = collection.OrderBy(y => y.price).ToList();
            foreach (MusicalInstruments instrument in sorted)
            {
                Console.WriteLine("Brand: {0}. Origin: {1}. Price: {2}.", instrument.brand, instrument.origin, instrument.price);
                Console.WriteLine();
            }
            // Брэнд инструмента с ценой менее 5000.
            var selectedPrices = from y in collection
                                 where y.price < 5000
                                 orderby y.brand
                                 select y.brand;
            foreach (var instrument in selectedPrices)
                Console.WriteLine(instrument);
            Console.WriteLine();

            // Инструменты не из Японии.
            var selectedNotJapan = collection.Where(y => y.origin != "Japan");
            foreach (var instrument in selectedNotJapan)
                Console.WriteLine("Brand: {0}. Origin: {1}. Price: {2}.", instrument.brand, instrument.origin, instrument.price);


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
