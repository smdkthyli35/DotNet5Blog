using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        [ValidationAspect(typeof(WriterValidator))]
        public void Add(Writer writer)
        {
            //ValidationTool.Validate(new WriterValidator(), writer);
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetList();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(w => w.WriterId == id);
        }

       // [ValidationAspect(typeof(WriterValidator))]
        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
