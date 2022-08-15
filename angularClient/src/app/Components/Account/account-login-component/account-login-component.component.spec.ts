import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountLoginComponentComponent } from './account-login-component.component';

describe('AccountLoginComponentComponent', () => {
  let component: AccountLoginComponentComponent;
  let fixture: ComponentFixture<AccountLoginComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountLoginComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountLoginComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
