using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddDataToICollection
{
    public class ModelSet
    {
        public string DownloadBatch { get; private set; }
        public string Remark { get; private set; }
        public virtual ICollection<Model> OriginalOrderProductHistories { get; private set; } = new List<Model>();

        public void AddModels(IList<Model> originalOrderProductHistories)
        {
            this.OriginalOrderProductHistories = originalOrderProductHistories;
        }
    }
    public class Model
    {
        public string Name { get; set; }
        public Model(string name)
        {
            Name = name;
        }
    }
}
