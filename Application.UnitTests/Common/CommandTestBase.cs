﻿using AppForSkills.Persistance;
using Moq;
using System;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly AppForSkillsDbContext _context;
        protected readonly Mock<AppForSkillsDbContext> _contextMock;

        public CommandTestBase()
        {
            _contextMock = AppForSkillsDbContextFactory.Create();
            _context = _contextMock.Object;
        }

        public void Dispose()
        {
            AppForSkillsDbContextFactory.Destroy(_context);
        }
    }
}
