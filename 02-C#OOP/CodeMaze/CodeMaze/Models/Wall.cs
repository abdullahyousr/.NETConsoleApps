using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMaze.Models
{
    internal class Wall : IMazeObject
    {
        public char Icon { get => '#'; }

        public bool IsSolid { get => true; }
    }
}
