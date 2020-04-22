using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFinder.model {

    public class RootObject {
        public Playlists playlists { get; set; }
    }

    public class Playlists {
        public List<Item> items { get; set; }
    }
     
    public class Item {
        public string id { get; set; }
        public string name { get; set; }
    }
}
