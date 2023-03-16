using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG
{
    public class Machine
    {
        private static Machine _instance;
        public static Machine Instance()
        {
            if (_instance == null)
                _instance = new Machine();

            return _instance;
        }

        public const int MACHINE_UNIT_COUNT = 1;
        public class MachineUnits
        {
            private MachineUnit[] _unit = new MachineUnit[MACHINE_UNIT_COUNT];
            public MachineUnit this[int index]
            {
                get { return _unit[index]; }
                set { _unit[index] = value; }
            }

            public MachineUnit this[string unitName]
            {
                get
                {
                    for (int i = 0; i < MACHINE_UNIT_COUNT; i++)
                    {
                        if (_unit[i].UnitName == unitName)
                            return _unit[i];
                    }

                    return null;
                }
                set
                {
                    for (int i = 0; i < MACHINE_UNIT_COUNT; i++)
                    {
                        if (_unit[i].UnitName == unitName)
                            _unit[i] = value;
                    }
                }
            }
        }

        public class MachineUnit
        {
            public string UnitName { get; set; } = "";

            public InspectionItem[,] InspectionParams;
        }

        public static MachineUnits Unit = new MachineUnits();

        public enum eStage
        {
            Stage1,
            Stage2
        }

        public enum eCam
        {
            Cam1,
            Cam2
        }

        public static void Initialize()
        {
            for (int machineUnitNo = 0; machineUnitNo < MACHINE_UNIT_COUNT; machineUnitNo++)
            {
                Unit[machineUnitNo] = new MachineUnit();

                Unit[machineUnitNo].InspectionParams = new InspectionItem[Enum.GetValues(typeof(eStage)).Length, Enum.GetValues(typeof(eCam)).Length];

                for (int stageNo = 0; stageNo < Enum.GetValues(typeof(eStage)).Length; stageNo++)
                {
                    for (int camNo = 0; camNo < Enum.GetValues(typeof(eCam)).Length; camNo++)
                        Unit[machineUnitNo].InspectionParams[stageNo, camNo] = new InspectionItem();
                }
            }
        }
    }
}
