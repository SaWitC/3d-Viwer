import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IcosaedrComponent } from './icosaedr.component';

describe('IcosaedrComponent', () => {
  let component: IcosaedrComponent;
  let fixture: ComponentFixture<IcosaedrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IcosaedrComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IcosaedrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
