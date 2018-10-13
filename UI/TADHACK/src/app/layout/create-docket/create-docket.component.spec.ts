import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDocketComponent } from './create-docket.component';

describe('CreateDocketComponent', () => {
  let component: CreateDocketComponent;
  let fixture: ComponentFixture<CreateDocketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateDocketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateDocketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
