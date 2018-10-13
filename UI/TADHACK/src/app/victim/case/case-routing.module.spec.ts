import { CaseRoutingModule } from './case-routing.module';

describe('CaseRoutingModule', () => {
  let caseRoutingModule: CaseRoutingModule;

  beforeEach(() => {
    caseRoutingModule = new CaseRoutingModule();
  });

  it('should create an instance', () => {
    expect(caseRoutingModule).toBeTruthy();
  });
});
