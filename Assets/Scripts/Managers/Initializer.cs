using HT.Framework;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Initializer
{
    public static Dictionary<string, string> PresetExps = new Dictionary<string, string>();

    public static void InitializeExperiments()
    {
        PresetExps.Add("BookV", "{\"FPSPosition\":{\"x\":-58.759,\"y\":10.282,\"z\":1.732},\"FPSRotation\":{\"x\":0.0,\"y\":-0.7,\"z\":0.0,\"w\":0.7},\"info\":{\"id\":-2,\"title\":\"存档-2\",\"time\":\"2021-07-08T14:54:52.2181929+08:00\",\"timeString\":\"2021年7月8日 14:54:52\"},\"procedureStack\":[\"StartProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"ChooseExpProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"AddValueProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"EnterExpressionProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"PreviewProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"],\"quantities\":[{\"Name\":\"长度\",\"Symbol\":\"l\",\"InstrumentType\":\"RulerInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"宽度\",\"Symbol\":\"d\",\"InstrumentType\":\"RulerInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"厚度\",\"Symbol\":\"h\",\"InstrumentType\":\"CaliperInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null}],\"complexQuantityModel\":{\"AverageState\":0,\"UncertainState\":0,\"AnswerAverageState\":0,\"AnswerUncertainState\":0,\"Average\":0.0,\"Uncertain\":0.0,\"AnswerAverage\":0.0,\"AnswerUncertain\":0.0,\"AverageExpression\":null,\"UncertainExpression\":null,\"AnswerAverageExpression\":null,\"AnswerUncertainExpression\":null},\"currentQuantityIndex\":0,\"stringExpression\":\"l*d*h\",\"instrumentStartPosition\":[0.0,0.0,0.0],\"objectStartPosition\":[0.0,0.0,0.0],\"showedInstrument\":null,\"showedObject\":null,\"objects\":[]}");
        PresetExps.Add("BookP", "{\"FPSPosition\":{\"x\":-58.759,\"y\":10.282,\"z\":1.732},\"FPSRotation\":{\"x\":0.0,\"y\":-0.7,\"z\":0.0,\"w\":0.7},\"info\":{\"id\":-2,\"title\":\"存档-2\",\"time\":\"2021-07-08T15:00:49.9042241+08:00\",\"timeString\":\"2021年7月8日 15:00:49\"},\"procedureStack\":[\"StartProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"ChooseExpProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"AddValueProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"EnterExpressionProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"PreviewProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"],\"quantities\":[{\"Name\":\"长度\",\"Symbol\":\"l\",\"InstrumentType\":\"RulerInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"宽度\",\"Symbol\":\"d\",\"InstrumentType\":\"RulerInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"厚度\",\"Symbol\":\"h\",\"InstrumentType\":\"CaliperInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"质量\",\"Symbol\":\"m\",\"InstrumentType\":\"ElectronicScalesInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null}],\"complexQuantityModel\":{\"AverageState\":0,\"UncertainState\":0,\"AnswerAverageState\":0,\"AnswerUncertainState\":0,\"Average\":0.0,\"Uncertain\":0.0,\"AnswerAverage\":0.0,\"AnswerUncertain\":0.0,\"AverageExpression\":null,\"UncertainExpression\":null,\"AnswerAverageExpression\":null,\"AnswerUncertainExpression\":null},\"currentQuantityIndex\":0,\"stringExpression\":\"m/(l*d*h)\",\"instrumentStartPosition\":[0.0,0.0,0.0],\"objectStartPosition\":[0.0,0.0,0.0],\"showedInstrument\":null,\"showedObject\":null,\"objects\":[]}");
        PresetExps.Add("VAResistor", "{\"FPSPosition\":{\"x\":-58.759,\"y\":10.282,\"z\":1.732},\"FPSRotation\":{\"x\":0.0,\"y\":-0.7,\"z\":0.0,\"w\":0.7},\"info\":{\"id\":-2,\"title\":\"存档-2\",\"time\":\"2021-07-08T15:03:17.1404558+08:00\",\"timeString\":\"2021年7月8日 15:03:17\"},\"procedureStack\":[\"StartProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"ChooseExpProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"AddValueProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"EnterExpressionProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"PreviewProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"],\"quantities\":[{\"Name\":\"电压\",\"Symbol\":\"u\",\"InstrumentType\":\"VoltmeterInstruction, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"电流\",\"Symbol\":\"i\",\"InstrumentType\":\"AmmeterInstruction, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null}],\"complexQuantityModel\":{\"AverageState\":0,\"UncertainState\":0,\"AnswerAverageState\":0,\"AnswerUncertainState\":0,\"Average\":0.0,\"Uncertain\":0.0,\"AnswerAverage\":0.0,\"AnswerUncertain\":0.0,\"AverageExpression\":null,\"UncertainExpression\":null,\"AnswerAverageExpression\":null,\"AnswerUncertainExpression\":null},\"currentQuantityIndex\":0,\"stringExpression\":\"u/i\",\"instrumentStartPosition\":[0.0,0.0,0.0],\"objectStartPosition\":[0.0,0.0,0.0],\"showedInstrument\":null,\"showedObject\":null,\"objects\":[]}");
        PresetExps.Add("Metalp", "{\"FPSPosition\":{\"x\":-58.759,\"y\":10.282,\"z\":1.732},\"FPSRotation\":{\"x\":0.0,\"y\":-0.7,\"z\":0.0,\"w\":0.7},\"info\":{\"id\":-2,\"title\":\"存档-2\",\"time\":\"2021-07-08T15:05:11.0142745+08:00\",\"timeString\":\"2021年7月8日 15:05:11\"},\"procedureStack\":[\"StartProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"ChooseExpProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"AddValueProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"EnterExpressionProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"PreviewProcedure, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"],\"quantities\":[{\"Name\":\"长度\",\"Symbol\":\"l\",\"InstrumentType\":\"RulerInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"直径\",\"Symbol\":\"d\",\"InstrumentType\":\"MicrometerInstrument, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"电压\",\"Symbol\":\"u\",\"InstrumentType\":\"VoltmeterInstruction, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null},{\"Name\":\"电流\",\"Symbol\":\"i\",\"InstrumentType\":\"AmmeterInstruction, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Groups\":8,\"Data\":[],\"Average\":0.0,\"Ua\":0.0,\"Ub\":0.0,\"Uncertain\":0.0,\"AverageState\":0,\"UaState\":0,\"UbState\":0,\"ComplexState\":0,\"AverageExpression\":null,\"UaExpression\":null,\"UbExpression\":null,\"ComplexExpression\":null}],\"complexQuantityModel\":{\"AverageState\":0,\"UncertainState\":0,\"AnswerAverageState\":0,\"AnswerUncertainState\":0,\"Average\":0.0,\"Uncertain\":0.0,\"AnswerAverage\":0.0,\"AnswerUncertain\":0.0,\"AverageExpression\":null,\"UncertainExpression\":null,\"AnswerAverageExpression\":null,\"AnswerUncertainExpression\":null},\"currentQuantityIndex\":0,\"stringExpression\":\"(4*l*i)/(u*pi*pi*d)\",\"instrumentStartPosition\":[0.0,0.0,0.0],\"objectStartPosition\":[0.0,0.0,0.0],\"showedInstrument\":null,\"showedObject\":null,\"objects\":[]}");
    }

    public static Record GetPresetRecord(string name)
    {
        return JsonConvert.DeserializeObject<Record>(PresetExps[name]);
    }

    /// <summary>
    /// 初始化被测物体
    /// </summary>
    public static void InitializeObjects()
    {
        if (GameManager.Instance.objectsModels.Count == 0)
        {
            GameManager.Instance.objectsModels = new List<ObjectsModel>()
                {
                    new ObjectsModel()
                    {
                        id = 0,
                        Name = "立方体",
                        DetailMessage = "纯正立方体",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/cubic.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object1.obj"
                    },
                    new ObjectsModel()
                    {
                        id = 1,
                        Name = "圆柱",
                        DetailMessage = "较高的一个圆柱",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/cylinder.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object2.obj"
                    },
                    new ObjectsModel()
                    {
                        id = 2,
                        Name = "圆柱",
                        DetailMessage = "较胖的一个圆柱",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/cylinder_low.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object3.obj"
                    },
                    new ObjectsModel()
                    {
                        id = 3,
                        Name = "圆环",
                        DetailMessage = "圆环",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/object4.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object4.obj"
                    },
                    new ObjectsModel()
                    {
                        id = 4,
                        Name = "圆筒",
                        DetailMessage = "带底的一个圆筒",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/object5.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object5.obj"
                    },
                    new ObjectsModel()
                    {
                        id = 5,
                        Name = "正四面体",
                        DetailMessage = "标准的正四面体",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/object6.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object6.obj"
                    },
                    new ObjectsModel()
                    {
                        id = 6,
                        Name = "杯子",
                        DetailMessage = "户外用杯子。可以用来测内径",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/object7.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object7.obj"
                    },
                    new ObjectsModel()
                    {
                        id = 7,
                        Name = "杯盖",
                        DetailMessage = "与杯子匹配的杯盖",
                        Integrated = true,
                        PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/object8.png",
                        ResourcePath = $"{Application.streamingAssetsPath}/Objects/object8.obj"
                    },
                };
        }
    }
}