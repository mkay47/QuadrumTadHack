import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VictimDashboardComponent } from './victim-dashboard.component';

describe('VictimDashboardComponent', () => {
  let component: VictimDashboardComponent;
  let fixture: ComponentFixture<VictimDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VictimDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VictimDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
