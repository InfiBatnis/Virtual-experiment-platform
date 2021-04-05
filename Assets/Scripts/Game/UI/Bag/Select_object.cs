using HT.Framework;
using DG.Tweening;
using System.Linq;
using System.Collections.Generic;

namespace UnityEngine.UI.Extensions.Examples.FancyScrollViewExample03
{
    class Select_object : HTBehaviour
    {
        //启用自动化
        protected override bool IsAutomate => true;

        [SerializeField] ScrollView scrollView = default;

        void Start()
        {
            if (RecordManager.tempRecord.objects.Count == 0)
            {
                RecordManager.tempRecord.objects = new List<ObjectsModel>()
                {
                    new ObjectsModel()
                    {
                         Name = "立方体",
                         DetailMessage = "纯正立方体",
                         Integrated = true,
                         PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/cubic.png"
                    },
                    new ObjectsModel()
                    {
                         Name = "圆柱",
                         DetailMessage = "较高的一个圆柱",
                         Integrated = true,
                         PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/cylinder.png"
                    },
                    new ObjectsModel()
                    {
                         Name = "圆柱",
                         DetailMessage = "较胖的一个圆柱",
                         Integrated = true,
                         PreviewImage = $"{Application.streamingAssetsPath}/PreviewImages/cylinder_low.png"
                    },
                };
            }
            var items = new ItemData[RecordManager.tempRecord.objects.Count];
            Debug.Log(items.Length);
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
        }
    }
}