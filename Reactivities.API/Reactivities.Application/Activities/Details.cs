﻿using MediatR;
using Reactivities.Domain;
using Reactivities.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reactivities.Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly ReactivitiesDbContext _context;
            public Handler(ReactivitiesDbContext context)
            {
                _context = context;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken) 
                => await _context.Activities.FindAsync(request.Id);
        }
    }
}