using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class FriendScore
    {
        public int HighestScore(string[] friends)
        {
            List<int>[] curGraph = new List<int>[friends.Length + 2];

            for(int index = 0; index < friends.Length; index++)
                {
                string[] vs = friends[index].Split(',');
                
                for(int index2 = 0; index2 < vs.Length; index2++)
                {
                    
                    if (curGraph[index2]==null)
                        curGraph[index2] = new List<int>();

                    for (int index3 = 0; index3 < vs[index2].Length; index3++)
                    {
                      //  Console.WriteLine(vu[index3]);  
                        if (vs[index2][index3] == 'Y')
                        {

                            curGraph[index2].Add(index3);
                                if (curGraph[index3] == null)
                                curGraph[index3] = new List<int>();
                            curGraph[index3].Add(index2);

                        }
                    }
                  // Console.WriteLine(vs[index2]);
                   
                }


            }
            for(int i = 0;i<curGraph.Length;i++)
            {
                if (curGraph[i] != null)
                {
                    Console.WriteLine(curGraph[i].Count);
                }
               
            }
            int ans = 0;
            for(int index = 0; index < friends.Length; index++)
            {
               Queue <int>myQueue = new Queue<int>();
                HashSet<int> myhash1 = new HashSet<int>();
                myQueue.Enqueue(index);
                int[] curArray = new int[friends.Length];
                while(myQueue.Count > 0)
                {
                    int top = myQueue.Peek();
                    myhash1.Add(top);
                    curArray[top] = 1;
                    myQueue.Dequeue();
                    if (curGraph[top] != null)
                    {
                        for (int index2 = 0; index2 < curGraph[top].Count; index2++)
                        {
                            if (curArray[curGraph[top][index2]] == 0)
                            {
                                curArray[curGraph[top][index2]] = 1;
                                myhash1.Add(curGraph[top][index2]);
                            }
                        }
                    }
                  
                    

                    

                }
                if(myhash1.Count == 10)
                {
                    Console.WriteLine("current index -: " + index);
                    for(int i  = 0; i < curGraph[index].Count; i++)
                    {
                        Console.WriteLine("parts " + curGraph[index][i]);
                    }
                }
                ans = Math.Max(ans, myhash1.Count);
                myhash1.Clear();
                myQueue.Clear();
                


            }
            
            return ans-1;





          //      return -1;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            FriendScore friendScore = new FriendScore();
            do
            {
                string[] values = input.Split(',');
                int validationOp = friendScore.HighestScore(values);
                Console.WriteLine(validationOp);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}