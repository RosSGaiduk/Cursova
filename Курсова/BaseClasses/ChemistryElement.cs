using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Курсова
{
    public interface StringOfElement
    {
        string getString();
    }

    public abstract class Element:StringOfElement
    {
        public Element() { }
     
        public int Id { get; set; }
        public string Description { get; set; }
        public string FullName { get; set; }
        public string Formula { get; set; }
        public string GraphicModel { get; set; }
        public List<EmptyPage> Pages { get; set; }   
        public virtual string getString() 
        {
            return "Full name:"+FullName;
        }
    }

    //[Table("ChemistryElement")]
    public class ChemistryElement : Element
    {
        public ChemistryElement() { }
        //для запису в бд без id, бо воно auto_increment
        public ChemistryElement(string f, string t, string d, int g, string v,
            int p, double aw, char or, string graphic, string formula, string natural)
        {
            FullName = f; TableTame = t; Description = d; Group = g; Valence = v;
            Period = p; AtomicWeight = aw; GraphicModel = graphic;
            Orbital = or; //UrlOfImage = url;
            Formula = formula;
            NaturalName = natural;
        }

        //для отримання з бд елемента потрібна Id
        public ChemistryElement(int id,string f, string t, string d, int g, string v,
            int p, double aw, char or, string graphic, string formula, string natural)
        {
            Id = id;
            FullName = f; TableTame = t; Description = d; Group = g; Valence = v;
            Period = p; AtomicWeight = aw; GraphicModel = graphic;
            Orbital = or; //UrlOfImage = url;
            Formula = formula;
            NaturalName = natural;
        }


        public string TableTame { get; set; }
        public int Group { get; set; }
        public string Valence { get; set; }
        public int Period { get; set; }
        public double AtomicWeight { get; set; }
        public char Orbital { get; set; }
        public string NaturalName { get; set; }
        public List<OrganicElement> OrganicElements { get; set; }
        public override string getString()
        {
            return base.getString()+"\nid: "+"#####"+"\ntable name: "+TableTame+"\ndescription: "+Description+"\ngroup: "+Group+"\nvalence: "+Valence+"\nperiod: "
                +Period+"\natomic weight: "+AtomicWeight+
                "\norbital: "+Orbital+"\ngraphic model: "+GraphicModel+"\nformula: "+Formula+"\nnatural name: "+NaturalName;
        }

        public string toStringFile()
        {
            return base.getString() + "\r\nid:" + Id + "\r\ntable name:" + TableTame+ "\r\ndescription:" + Description + "\r\ngroup:" + Group + "\r\nvalence:" + Valence + "\r\nperiod:"
                + Period + "\r\natomic weight: " + AtomicWeight +
                "\r\norbital:" + Orbital + "\r\ngraphic model:" + GraphicModel + "\r\nformula:" + Formula + "\r\nnatural name:" + NaturalName+ "\r\n^\r\n";
        }
        
        public override string ToString()
        {
            return getString();
        }

        public void writeToFile(String nameFile)
        {
            File.AppendAllText(nameFile,toStringFile());
        }
    }

    //[Table("OrganicElement")]
    public class OrganicElement : Element
    {

        public OrganicElement() { }


        public OrganicElement(string descr, string fname, string formula, string graphModel)
        {
            Description = descr; FullName = fname; Formula = formula; GraphicModel = graphModel;
        }

        public OrganicElement(int id,string descr,string fname,string formula,string graphModel)
        {
            Id = id; Description = descr; FullName = fname; Formula = formula; GraphicModel = graphModel;
        }

        public List<ChemistryElement> ChemistryElements { get; set; }
        public override string getString()
        {
            string str = "";
            for (int i = 0; i < ChemistryElements.Count; i++)
                str += ChemistryElements[i].getString() + "\n";
            return str;
        }

        public override string ToString()
        {
            return "Id: " + "#####" + "\nDescription: " + Description + "\nFull name: " + FullName + "\nGraphic model: " + GraphicModel;
        }
    }
    //[Table("Picture")]
    public class Picture
    {
        public Picture() { }
        public Picture(string url)
        {
            UrlOfImage = url;
        }

        public Picture(int id,string url)
        {
            Id = id;
            UrlOfImage = url;
        }

        public int Id { get; set; }
        public string UrlOfImage { get; set; }
        public HashSet<PageWithTextAndImage> Pages { get; set; }

        public override string ToString()
        {
            return "Url of image: "+UrlOfImage;
        }
    }

    public abstract class EmptyPage
    {
        public int Id { get; set; }
        public int NumberOfPage { get; set; }
        public List<Element> Elements { get; set; }
    }
    
    //[Table("PageWithTextAndImage")]
    public class PageWithTextAndImage:EmptyPage
    {
        public PageWithTextAndImage() { }
        public PageWithTextAndImage(int number,string text)
        {
            NumberOfPage = number; TextInPage = text;
        }
        public PageWithTextAndImage(int id,int number, string text)
        {
            Id = id; NumberOfPage = number; TextInPage = text;
        }

        public string TextInPage { get; set; }
        public HashSet<Picture> Pictures { get; set; }

        public override string ToString()
        {
            return "Id: " + "#####" + "\nNumber of page: " + NumberOfPage + "\nText in page: " + TextInPage;
        }
    }
}

