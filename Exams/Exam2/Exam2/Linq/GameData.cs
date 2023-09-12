namespace Exam2
{
    public class GameData
    {
        public string name;
        public string platform;
        public long year;
        public string genre;
        public string publisher;
		//تعداد فروش در آمریکا
        public double NA_sales;
		//تعداد فروش در اروپا
        public double EU_sales;
		//تعداد فروش در ژاپن
        public double JP_sales;
		//تعداد فروش در بقیه جاهای جهان
        public double Other_sales;
		//تعداد فروش در کل دنیا
        public double Global_sales;

        public GameData(string[] fields)
        {
            name = fields[0];
            platform = fields[1];
            year = long.Parse(fields[2]);
            genre = fields[3];
            publisher = fields[4];
            NA_sales = double.Parse(fields[5]);
            EU_sales = double.Parse(fields[6]);
            JP_sales = double.Parse(fields[7]);
            Other_sales = double.Parse(fields[8]);
            Global_sales = double.Parse(fields[9]);
        }
    }
}
