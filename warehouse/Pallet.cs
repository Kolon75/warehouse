using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehouse
{
    public class Pallet : IComparer<Pallet>
    {
        public virtual int IdPallet { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual int Depth { get; set; }
        public virtual int Weight { get; set; }
        public virtual int Volume { get; set; }
        public virtual DateTime Date { get; set; }

        public List<Box> Boxes = new List<Box>();

        public Pallet()
        {
           
        }
        public Pallet(int idPallet)
        {
            IdPallet = idPallet;
            Width = 800;
            Height = 144;
            Depth = 1200;
            Weight = 30;
        }

        public int Compare(Pallet x, Pallet y)
        {
            if (x.Volume < y.Volume)
            {
                return -1;
            }
            else if (x.Volume > y.Volume)
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }
    }
    public class Box: Pallet 
    {

        public override int IdPallet { get; set; }
        public int IdBox { get; set; }

        private int width;
        public override int Width
        {
            get { return width; }
            set
            {
                if (value > 800)
                {
                    width = 800;
                }
                else
                {
                    width = value; 
                }
            }
        }
        public override int Height { get; set; }
        private int depth;
        public override int Depth
        {
            get { return width; }
            set
            {
                if (value > 1200)
                {
                    depth = 1200;
                }
                else
                {
                    depth = value;
                }
            }
        }
        public override int Weight { get; set; }
        public override int Volume { get; set; }
        public override DateTime Date { get; set; }

        public Box(int idPallet, int idbox, int width, int height, int depth, int weight, DateTime date) : base(idPallet)
        {
            IdPallet = idPallet;
            IdBox = idbox;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            Volume = width * height * depth;
            Date = date;
        }

    }

}
