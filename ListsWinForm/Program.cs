using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListsWinForm
{
    public class rabot
    {
        string name;
        int zarp, doli;
        string dols, gor, ul, dom;
        public string Name { get { return name; } }
        public int Doli { get { return doli; } }
        public int Zarp { get { return zarp; } }
        public rabot(string _name, int _doli, string _dols, int _zarp, string _gor, string _ul, string _dom) { name = _name; doli = _doli; dols = _dols; zarp = _zarp; gor = _gor; ul = _ul; dom = _dom; }
        public override string ToString()
        {
            return $"{name} - {dols} - {zarp} | {gor} : {ul} : {dom}";
        }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
