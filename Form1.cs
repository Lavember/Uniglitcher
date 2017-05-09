using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Uniglitcher
{
    public partial class Form1 : Form
    {
        string toGlitch;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AddExtension = true;
            dialog.ShowDialog();
            dialog.DefaultExt = "uni";
            dialog.Filter = "Unimaker (*.uni)|*.uni";
            toGlitch = dialog.FileName;
            if(toGlitch != "")
            {
                button2.Enabled = true;
                label2.Text = toGlitch;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(toGlitch != "")
            {
                listAlterations.Items.Clear();
                string[] flines = File.ReadAllLines(toGlitch);
                string[] nlines = new string[flines.Length];
                for(int i = 0;i < nlines.Length; i++)
                {

                    if (i == 0)
                    {
                        /*
                         * A primeira linha é basicamente o bioma do mapa
                         * 0-23
                         */

                        int ranGen = new Random().Next(Convert.ToInt32(flines[i]), 23);
                        nlines[i] = ranGen.ToString();
                        listAlterations.Items.Add("Bioma do mapa mudado para " + ranGen.ToString());

                    } else if (i == 1)
                    {
                        /*
                         * Segunda linha é o tamanho do mapa
                         * 0-16
                         */
                        int ranGen = new Random().Next(0, 16);
                        nlines[i] = ranGen.ToString();
                        listAlterations.Items.Add("Tamanho do mapa mudado para " + ranGen.ToString());

                    } else if (i == 2)
                    {
                        /*
                         * A terceira linha é o tempo
                         * 1-9999
                         */
                        int ranGen = new Random().Next(1, 9999);
                        nlines[i] = ranGen.ToString();
                        listAlterations.Items.Add("Tempo do mapa mudado para " + ranGen.ToString());

                        /*
                         * a linha 4 n sei oq faz
                         */
                    } else if(i == 4)
                    {
                        /*
                         * a linha 5 é o autoscroll
                         * 0-4
                         */

                        int ranGen = new Random().Next(0, 4);
                        nlines[i] = ranGen.ToString();
                        listAlterations.Items.Add("Scroll do mapa mudado a " + ranGen);

                    } else if (i == 5)
                    {
                        /*
                         * a linha 6 é a mais intrigante
                         * ela contém tds os blocos do mapa ajunto de posições
                         * 
                         */
                        string aaa = flines[i];
                        StringBuilder newer = new StringBuilder(aaa);
                        
                        for(int a = 0; a < aaa.Length; a++)
                        {


                            if(aaa[a] == 'F')
                            {
                                newer[a] = 'A';
                                listAlterations.Items.Add("Mudado " + aaa[a] + " em " + a.ToString() + " para " + newer[a]);

                            } else if (aaa[a] == 'B')
                            {
                                //newer[a] = 'C';
                                //listAlterations.Items.Add("Mudado " + aaa[a] + " em " + a.ToString() + " para " + newer[a]);

                            }
                            else if (aaa[a] == 'D')
                            {
                                //newer[a] = 'E';

                            }
                            else if (aaa[a] == '1')
                            {
                                //newer[a] = '2';
                                //listAlterations.Items.Add("Mudado " + aaa[a] + " em " + a.ToString() + " para " + newer[a]);

                            }
                            else if (aaa[a] == '3')
                            {
                                //newer[a] = '4';
                                //listAlterations.Items.Add("Mudado " + aaa[a] + " em " + a.ToString() + " para " + newer[a]);

                            }
                            else if (aaa[a] == '5')
                            {
                                //[a] = '6';

                            }
                            else if (aaa[a] == '7')
                            {
                                //newer[a] = '8';

                            }
                            else if (aaa[a] == '9')
                            {
                                //newer[a] = '1';

                            }


                        }

                        nlines[i] = newer.ToString();


                    }




                }


                SaveFileDialog dialog = new SaveFileDialog();
                dialog.AddExtension = true;
                dialog.ShowDialog();
                dialog.DefaultExt = "uni";
                dialog.Filter = "Unimaker (*.uni)|*.uni";

                if (dialog.FileName == "")
                {
                    MessageBox.Show("ESCOLHA UM ARQUIVO E TENT NOVAMENT SEU BATATINHA");
                    return;
                }

                string file = dialog.FileName;

                File.WriteAllLines(file, nlines);

            }



        }
    }
}
