using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDialog_Zach
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string content;
            string pathfile;   // Diese Variable wird nicht weiterverwendet und kann daher gelöscht werden!

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Text File";
            ofd.Filter = "TXT files|*.txt"; // Beim OPENFileDialog empfiehlt es sich einen zweiten Filter auf All Files zu setzen, da es passieren kann (siehe bei meinem Firmenrechner) das ein .txt Filter alleine nicht funktioniert und somit könnte ich nun keine Datei öffnen! 
            ofd.InitialDirectory = @"C:\";  // Sehr gut, somit "sollte" der OFD auf jedem "Windows" Rechner funktionieren! 
          
            // Bei ihrer Überprüfung  "if (ofd.ShowDialog() != DialogResult.OK)"  würde der Compiler nur in die Bedingung gehen wenn Dialog.Result.OK NICHT OK wäre...was es aber müsste und auch zu 99,9% ist! 
            // Auch der StreamReader ist nicht zwingend notwendig, da direkt in der Bedinung selbst eine Ausgabe der eingelesenen Datei erfolgen kann. Es genügt dafür schon Console.WriteLine(ofd.Filenme);
           
//             RICHTIG WÄRE:
//             if (ofd.ShowDialog() == DialogResult.OK){
//                 Console.WriteLine(ofd.Filename);        ....od. was auch immer ich mit der Datei machen möchte....
//                 }
            
               // Od. wenn es der StreamReader sein soll.....
            
//             if (ofd.ShowDialog() == DialogResult.OK){
//                     using (StreamReader sr = new StreamReader(ofd.FileName))
//                     {
//                     content = sr.ReadToEnd();
//                     Console.WriteLine(content);
//                     sr.Dispose();  
//                     sr.Close();   
//                      }
// //                   ....od. was auch immer ich mit der Datei machen möchte....
// //                 }
            
            
            if (ofd.ShowDialog() != DialogResult.OK)  
            {
                MessageBox.Show(ofd.FileName.ToString()); // Messagebox ist in Verbindung mit dem OpenFiledDialog nicht empfehlenswert, die Gründe dafür haben wir am Freitag besprochen!
                pathfile = ofd.FileName;  // Dies Zuweisung ist nicht nötig, mit ofd.FileName kann, wie sie es selbst weite unten un, ganz normal weitergearbeitet werden.
            }

            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                content = sr.ReadToEnd();
                Console.WriteLine(content);
                sr.Dispose();  
                sr.Close();   
            }
            
            

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";  // Sehr gut, beim speichern ist der Filter All Files irritierend und daher emphielt es sich diesen nicht zu verwenden!

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.OpenFile()))
                {
                    writer.WriteLine(content);
                    writer.WriteLine("\n\n This is additional!");

                    writer.Dispose();   // Sehr gut!
                    writer.Close();  // Sehr gut!
                }
            }             
            Console.ReadLine();
        }
    }
}
