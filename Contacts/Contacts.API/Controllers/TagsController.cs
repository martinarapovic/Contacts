using AutoMapper;
using Contacts.API.Filters;
using Contacts.API.ViewModels;
using Contacts.Models;
using Contacts.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Contacts.API.Controllers
{
    public class TagsController : ApiController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IHttpActionResult Get()
        {
            var tags = _tagService.GetTags();
            var tagViewModels = new List<TagViewModel>();
            Mapper.Map(tags, tagViewModels);

            return Ok(tagViewModels);
        }

        public IHttpActionResult Get(int id)
        {
            var tag = _tagService.GetTag(id);
            var tagViewModel = new TagViewModel();
            Mapper.Map(tag, tagViewModel);

            return Ok(tagViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Post(TagViewModel tagViewModel)
        {
            var tag = new Tag();
            Mapper.Map(tagViewModel, tag);
            _tagService.AddTag(tag);
            tagViewModel.TagId = tag.TagId;

            return Created(Url.Link("DefaultApi", new { controller = "Tags", id = tagViewModel.TagId }), tagViewModel);
        }

        [ValidateViewModelFilter]
        public IHttpActionResult Put(int id, TagViewModel tagViewModel)
        {
            tagViewModel.TagId = id;
            var tag = _tagService.GetTag(id);
            Mapper.Map(tagViewModel, tag);
            _tagService.UpdateTag(tag);

            return Ok(tagViewModel);
        }

        public IHttpActionResult Delete(int id)
        {
            _tagService.DeleteTag(id);

            return Ok();
        }
    }
}