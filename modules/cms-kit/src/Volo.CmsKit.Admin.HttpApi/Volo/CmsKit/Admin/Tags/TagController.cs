﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.CmsKit.Admin.Tags;
using Volo.CmsKit.Permissions;
using Volo.CmsKit.Tags;

namespace Volo.CmsKit.Admin.Tags
{
    public class TagController : CmsKitAdminController, ITagAdminAppService
    {
        protected ITagAdminAppService TagAdminAppService { get; }

        public TagController(ITagAdminAppService tagAdminAppService)
        {
            TagAdminAppService = tagAdminAppService;
        }

        [HttpPost]
        [Authorize(CmsKitAdminPermissions.Tags.Create)]
        public Task<TagDto> CreateAsync(TagCreateDto input)
        {
            return TagAdminAppService.CreateAsync(input);
        }

        [HttpDelete("{id}")]
        [Authorize(CmsKitAdminPermissions.Tags.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return TagAdminAppService.DeleteAsync(id);
        }

        [HttpGet("{id}")]
        [Authorize(CmsKitAdminPermissions.Tags.Default)]
        public Task<TagDto> GetAsync(Guid id)
        {
            return TagAdminAppService.GetAsync(id);
        }

        [HttpGet]
        [Authorize(CmsKitAdminPermissions.Tags.Default)]
        public Task<PagedResultDto<TagDto>> GetListAsync(TagGetListInput input)
        {
            return TagAdminAppService.GetListAsync(input);
        }

        [HttpPut("{id}")]
        [Authorize(CmsKitAdminPermissions.Tags.Update)]
        public Task<TagDto> UpdateAsync(Guid id, [FromBody] TagUpdateDto input)
        {
            return TagAdminAppService.UpdateAsync(id, input);
        }
    }
}
