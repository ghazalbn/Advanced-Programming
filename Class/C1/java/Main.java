class Main
{
    static <_Type> void Reverse(_Type[] list)
    {
        for(int j = 0;j< list.length/2;j++)
                {
                    _Type tmp = list[j];
                    list[j] = list[list.length-j-1];
                    list[list.length-j-1] = tmp;
                }
               
            }
    

    static <_Type> void ReverseOutput(_Type ... list)
    {
        Reverse(list);
                for(_Type i : list)
                {
                    System.out.print(i);
                    if(i != list[list.length-1])
                    System.out.print(',');
                }
        
    }

    // static <_Type> _Type[] GetArray(_Type ... args)
    // {
    //     _Type[] list = new _Type[args.length];
    //     for(int i=0; i<args.length; i++)
    //     {
    //         list[i] = args[i];
    //     }
    //     return list;
    // }

    public static void main(String[] args) {
        ReverseOutput(1,2,3,4,5,6,7,8);
    }
}