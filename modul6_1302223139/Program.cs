using System.Diagnostics.Contracts;

class Program
{

    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public String Username;

        public SayaTubeUser(String username)
        {
            if (string.IsNullOrEmpty(username) || username.Length > 100)
            {
                throw new ArgumentException("Username maksimal 200 karakter dan tidak null.");
            }

            this.Username = username;
            var rand = new Random();
            this.id = rand.Next(9999);
            uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int jmlh = 0;
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                jmlh = jmlh + uploadedVideos[i].getPlayCount();
            }
            return jmlh;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine("Pengguna : " + Username);
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine("Video " + (i + 1) + " judul : " + uploadedVideos[i].getTitle());
            }
        }
    }

    public class SayaTubeVideo
    {
        private int id;
        private String title;
        private int playCount;

        public SayaTubeVideo(String title)
        {
            if(string.IsNullOrEmpty(title) || title.Length > 200)
            {
                throw new ArgumentException("Judul video maksimal 200 karakter dan tidak null.");
            }
            var rand = new Random();
            this.id = rand.Next(9999);
            this.title = title;
            this.playCount = 0;

        }


        public void IncreasePlayCount(int jmlh)
        {
            Contract.Requires<ArgumentOutOfRangeException>(jmlh >= 0 && 
                jmlh <= 25_000_000, "Play Count harus diantara 0 sampai 25.000.000");
            playCount += jmlh;
            try
            {
                checked
                {
                    playCount += jmlh;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Jumlah play count melebihi batas maksimal");
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Title : " + title);
            Console.WriteLine("Play count : " + playCount);
        }

        public int getPlayCount()
        {
            return playCount;
        }

        public String getTitle()
        {
            return title;
        }
    }

    static void Main(String[] args)
    {
        SayaTubeUser pengguna1 = new SayaTubeUser("Ihsan");
        SayaTubeVideo video1 = new SayaTubeVideo("Review Film Goodfellas oleh Ihsan");
        pengguna1.AddVideo(video1);
        video1.IncreasePlayCount(12345);
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film Oldboy oleh Ihsan");
        pengguna1.AddVideo(video2);
        video2.IncreasePlayCount(98760);
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film American Beauty oleh Ihsan");
        pengguna1.AddVideo(video3);
        video3.IncreasePlayCount(56743);
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film Inception oleh Ihsan");
        pengguna1.AddVideo(video4);
        video4.IncreasePlayCount(11111);
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film I Saw The Devil oleh Ihsan");
        pengguna1.AddVideo(video5);
        video5.IncreasePlayCount(22222);
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film Scarface oleh Ihsan");
        pengguna1.AddVideo(video6);
        video6.IncreasePlayCount(33333);
        SayaTubeVideo video7 = new SayaTubeVideo("Review Film Reservoir Dogs oleh Ihsan");
        pengguna1.AddVideo(video7);
        video7.IncreasePlayCount(44444);
        SayaTubeVideo video8 = new SayaTubeVideo("Review Film Watchmen oleh Ihsan");
        pengguna1.AddVideo(video8);
        video8.IncreasePlayCount(55555);
        SayaTubeVideo video9 = new SayaTubeVideo("Review Film Rosermary's Baby oleh Ihsan");
        pengguna1.AddVideo(video9);
        video9.IncreasePlayCount(66666);
        SayaTubeVideo video10 = new SayaTubeVideo("Review Film The Raid oleh Ihsan");
        pengguna1.AddVideo(video10);
        video10.IncreasePlayCount(77777);


        video5.PrintVideoDetails();
        Console.WriteLine();

        Console.WriteLine(pengguna1.Username + " memiliki total playcount : " + pengguna1.GetTotalVideoPlayCount());
        Console.WriteLine();

        pengguna1.PrintAllVideoPlaycount();
        Console.WriteLine();
    }
}