namespace HS.Models
{
    public class Boat
    {
        public string Name
        {
            get;
            set;
        }

        public byte CabinsNum
        {
            get;
            set;
        }

        public HullType HullType
        {
            get;
            set;
        }

        public DriveType DriveType
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "Name: " + this.Name + " Location: " + this.Location +
                " Num Cabins: " + this.CabinsNum + " HullType: " + this.HullType +
                " Drive type: " + this.DriveType;
        }
    }
}
