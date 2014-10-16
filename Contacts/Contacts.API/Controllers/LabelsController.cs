using AutoMapper;
using Contacts.API.Filters;
using Contacts.API.ViewModels;
using Contacts.Models;
using Contacts.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Contacts.API.Controllers
{
    public class LabelsController : ApiController
    {
        private readonly ILabelService _labelService;

        public LabelsController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        public IHttpActionResult Get()
        {
            var labels = _labelService.GetLabels();
            var labelViewModels = new List<LabelViewModel>();
            Mapper.Map(labels, labelViewModels);

            return Ok(labelViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var label = _labelService.GetLabel(id);
            var labelViewModel = new LabelViewModel();
            Mapper.Map(label, labelViewModel);

            return Ok(labelViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Post(LabelViewModel labelViewModel)
        {
            var label = new Label();
            Mapper.Map(labelViewModel, label);
            label = _labelService.AddLabel(label);
            labelViewModel.LabelId = label.LabelId;

            return Created(Url.Link("DefaultApi", new { controller = "Labels", id = labelViewModel.LabelId }), labelViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Put(int id, LabelViewModel labelViewModel)
        {
            labelViewModel.LabelId = id;
            var label = _labelService.GetLabel(id);
            Mapper.Map(labelViewModel, label);
            _labelService.UpdateLabel(label);

            return Ok(labelViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            _labelService.DeleteLabel(id);

            return Ok();
        }
    }
}