using COG.Class;
using COG.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG
{
    public class Settings
    {
        private OperationParameter _operation = new OperationParameter();
        public OperationParameter Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        private RecipeParameter _recipe = new RecipeParameter();
        public RecipeParameter Recipe
        {
            get { return _recipe; }
            set { _recipe = value; }
        }

        private InspectionItem _inspection = new InspectionItem();
        public InspectionItem Inspection
        {
            get { return _inspection; }
            set { _inspection = value; }
        }

        private static Settings _instance = null;
        public static Settings Instance()
        {
            if (_instance == null)
                _instance = new Settings();

            return _instance;
        }

        public void Save()
        {
            _operation.Save();
            _recipe.Save();
            _inspection.Save();
        }

        public bool Load()
        {
            bool ret = true;
            ret = _operation.Load();

            if (ret)
            {
                // 추가 로딩할 것들
            }

            return ret;
        }
    }
}
