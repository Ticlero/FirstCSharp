using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinForm_ex
{
    class Program : Form
    {
        Random rand;
        static void Main(string[] args)
        {
            //print_01();
            //print_02();
            //print_03();
            //print_04();
            print_05();
        }
        public Program()
        {
            rand = new Random();
        }
        static void print_01()
        {
            Program p = new Program();
            p.Click += new EventHandler(
                (sender, eventArgs) =>
                {
                    Console.WriteLine("Closing Window...");
                    Application.Exit();
                });

            Console.WriteLine("Starting Window Application");
            Application.Run(p);

            Console.WriteLine("Exitng Window Application");
        }

        static void print_02()
        {
            Application.AddMessageFilter(new MessageFilter());
            Application.Run(new Program());
        }

        static void print_03()
        {
            Application.Run(new MouseEvnet("Mouse Event Test"));
        }

        static void print_04()
        {
            Program p = new Program();
            p.Width = 300;
            p.Height = 200;

            p.MouseDown += new MouseEventHandler(form_MouseDown);

            Application.Run(p);
            
        }

        static void print_05()
        {
            Program p = new Program();

            p.MaximizeBox = true;
            p.MinimizeBox = false;
            p.Text = "Example Form";

            Button button = new Button();
            button.Text = "Click!";
            button.Left = 100;
            button.Top = 50;

            button.Click += (object sender, EventArgs e) =>
            {
                MessageBox.Show("딸깍 딸깍!!");
            };

            p.Controls.Add(button);

            p.MouseWheel += new MouseEventHandler(p.P_MouseWheel);
            p.MouseDown += new MouseEventHandler(p.P_MouseDown);

            Application.Run(p);

        }
        static void form_MouseDown(object sender, MouseEventArgs e)
        {
            Form form = (Form)sender;
            int oldWidth = form.Width;
            int oldHeight = form.Height;

            if (e.Button == MouseButtons.Left)
            {
                if (oldWidth < oldHeight)
                {
                    form.Width = oldHeight;
                    form.Height = oldWidth;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (oldHeight < oldWidth)
                {
                    form.Width = oldHeight;
                    form.Height = oldWidth;
                }
            }

            Console.WriteLine("윈도우의 크기가 변경되었습니다.");
            Console.WriteLine($"Width: {form.Width}, Height: {form.Height}");
        }

        public void P_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Color color = this.BackColor;
                this.BackColor = Color.FromArgb(rand.Next(0, 255),
                    rand.Next(0, 255), rand.Next(0, 255));
            }else if(e.Button == MouseButtons.Right)
            {
                if(this.BackgroundImage !=null)
                {
                    this.BackgroundImage = null;
                    return;
                }

                string file = "sample.jpg";
                if(System.IO.File.Exists(file) == false)
                {
                    MessageBox.Show("이미지 파일이 없습니다.");
                }
                else
                {
                    this.BackgroundImage = Image.FromFile(file);
                }
            }
        }

        public void P_MouseWheel(object sender, MouseEventArgs e)
        {
            
            this.Opacity = this.Opacity + (e.Delta > 0 ? 0.1 : -0.1);
            Console.WriteLine($"Opacity: {this.Opacity}");
        }
    }
}
