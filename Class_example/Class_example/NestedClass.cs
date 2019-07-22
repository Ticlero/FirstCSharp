using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    class NestedClass
    {
        List<ItemValue> listConfig = new List<ItemValue>();

        public void SetConfig(string item, string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this, item, value);
        }

        public string GetConfig(string item)
        {
            foreach (ItemValue iv in listConfig)
            {
                if (iv.GetItem() == item)
                    return iv.GetValue();
            }
            return "";
        }

        class ItemValue
        {
            private string item;
            private string value;

            public void SetValue(NestedClass config, string item, string value)
            {
                this.item = item;
                this.value = value;

                bool found = false;
                for (int i = 0; i < config.listConfig.Count; i++)
                {
                    if (config.listConfig[i].item == item)
                    {
                        config.listConfig[i] = this; //NestedClass의 SetConfig메소드에서 생성된 ItemValue 객체를 나타냄
                        found = true;
                        break;
                    }
                }
                if (found == false)
                    config.listConfig.Add(this);
            }

            public string GetItem()
            {
                return item;
            }

            public string GetValue()
            {
                return value;
            }
        }
    }
}
