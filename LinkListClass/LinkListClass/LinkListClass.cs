using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListClass
{
    class SingleLinkListInt
    {
        public SingleLinkListInt()
        {
            head = null;
            last = null;
        }

        /// <summary>
        /// add an item at the list end
        /// </summary>
        /// <param name="val"></param>
        public void Add(int val)
        {
            if (head == null)
            {
                head = new Item();
                head.value = val;
                head.next = null;
                last = head;
            }
            else
            {
                last.next = new Item();
                last = last.next;
                last.next = null;
                last.value = val;
            }
        }

        /// <summary>
        /// // delete first item which match the argument
        /// </summary>
        /// <param name="val"></param>
        /// <returns>return false if non exist , return true if exist</returns>
        public bool Remove(int val)
        {
            // -- be carefull !!! there are few use cases here !!!
            Item temp = head;
            bool bRemoved = false;
            if(head != null)
            {
                if(head.value == val)
                {
                    head = head.next;
                    bRemoved = true;
                }
                else
                {
                    // --- we are checking temp.next so we can update next pointer upon delete
                    while (temp.next != null)
                    {
                        if (temp.next.value == val)
                        {
                            temp.next = temp.next.next;
                            bRemoved = true;
                            break;
                        }
                        temp = temp.next;
                    }
                }

                if(temp.next == null)
                {
                    last = temp;
                }
            }


            return bRemoved;
        }

        /// <summary>
        /// count number of items in list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int nCount = 0;
            Item temp = head;
            while (temp != null)
            {
                nCount++; ;
                temp = temp.next;
            }
            return nCount;
        }

        /// <summary>
        /// check if item exist or not
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Contains(int val)
        {
            Item temp = head;
            bool bContains = false;
            while (temp != null)
            {
                if(temp.value == val)
                {
                    bContains = true;
                    break;
                }
                temp = temp.next;
            }

            return bContains;
        }

#if DEBUG
        public void DebugPrint()
        {
            Item temp = head;
            Console.WriteLine("list items : ");
            while (temp != null)
            {
                Console.WriteLine(temp.value);
                temp = temp.next;
            }
        }
#endif

        private Item head;
        private Item last;
    }
}

