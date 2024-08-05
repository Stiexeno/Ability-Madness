using System.Collections.Generic;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Infrastructure.Services.Configs;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler
{
    public class AttachmentCalculatorService : IAttachmentCalculatorService
    {
        private IConfigsService _configsService;

        private const int maxAttachments = 3;

        public AttachmentCalculatorService(IConfigsService configsService)
        {
            _configsService = configsService;
        }

        public AttachmentConfig[] GenerateAttachments()
        {
            var configs = new List<AttachmentConfig>(_configsService.AttachmentConfigs);

            var attachments = new AttachmentConfig[maxAttachments];

            for (int i = 0; i < maxAttachments; i++)
            {
                attachments[i] = configs.RandomResult();
                configs.Remove(attachments[i]);
            }

            return attachments;
        }
    }
}
