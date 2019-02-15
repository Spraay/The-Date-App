using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Validator
{
    public class BaseMapper <Object1, Object2> : MapperConfigurationExpression, IBaseMapper<Object1, Object2>
    {
        public Object1 Class1 { get; set; }
        public Object2 Class2 { get; set; }

        public IMappingExpression<Object1, Object2> Class1_To_Class2()
        {
            return CreateMap<Object1, Object2>();
        }
        
        public IMappingExpression<Object2, Object1> Class2_To_Class1()
        {
            return CreateMap<Object2, Object1>();
        }
    }
}
