using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using System.Windows.Forms;
using System.IO;

namespace ShapeApplication
{
    public class FileManager
    {
        bool saved;
        private string saveFilepath;
        public List<Shape> shapeList;
        public Utility utility;
        int counter;

        public FileManager(List<Shape> shapes)
        {
            shapeList = shapes;
            utility = new Utility(shapeList);
            saved = false;
            saveFilepath = "";
            counter = 0;
        }

        public void save()
        {
            if (!saved)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "Shape" + counter.ToString() + ".txt";
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    CompositeImage ci = new CompositeImage(save.FileName);
                    saveFilepath = save.FileName;
                    StreamWriter writer = new StreamWriter(save.OpenFile());
                    for (int i = 0; i < shapeList.Count(); i++)
                    {
                        writer.WriteLine(shapeList[i].ToString());
                        ci.addShape(shapeList[i]);
                    }
                    writer.Dispose();
                    writer.Close();
                    counter++;
                    saved = true;
                }
            }
            else
            {
                CompositeImage ci = new CompositeImage(saveFilepath);
                using (StreamWriter writer = File.AppendText(saveFilepath))
                {
                    for (int i = 0; i < shapeList.Count(); i++)
                    {
                        writer.WriteLine(shapeList[i].ToString());
                        ci.addShape(shapeList[i]);
                    }
                    writer.Dispose();
                    writer.Close();
                }
            }
        }

        public void saveAs()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Shape" + counter.ToString() + ".txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                CompositeImage ci = new CompositeImage(save.FileName);
                saveFilepath = save.FileName;
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for (int i = 0; i < shapeList.Count(); i++)
                {
                    writer.WriteLine(shapeList[i].ToString());
                    ci.addShape(shapeList[i]);
                }
                writer.Dispose();
                writer.Close();
                counter++;
                saved = true;
            }
        }

        public bool open()
        {
            if (!saved)
            {
                if (MessageBox.Show("You haven't saved your work yet. Proceed?", "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public void openFile()
        {
            int count = 0;
            string line;
            string filepath = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            if (filepath != "")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filepath);
                while ((line = file.ReadLine()) != null)
                {
                    shapeList.Add(utility.readShape(line));
                    count++;
                }

                file.Close();
            }

        }
    }
}
