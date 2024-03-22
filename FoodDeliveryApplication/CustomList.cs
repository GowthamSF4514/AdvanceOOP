using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        private Type[] _array;
        public int Count { get{return _count;} }
        public int Capacity { get{return _capacity;}}
        public Type this[int index]{get{return _array[index];} set{_array[index]=value;}}
        public CustomList(){
            _count=0;
            _capacity=0;
            _array=new Type[_capacity];
        }
        public CustomList(int size){
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];
        }
        public void Add(Type element){
            if(_count==_capacity){
                Grow();
            }
            _array[_count]=element;
            _count++;
        }

        public void Grow(){
            _capacity=_capacity*2+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++){
                temp[i]=_array[i];
            }
            _array=temp;
        }

    }
}