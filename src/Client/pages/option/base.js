import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { InputTextarea } from 'primereact/inputtextarea';
import { Dropdown } from 'primereact/dropdown';

import { Checkbox } from "primereact/checkbox";

const FormLayoutDemo = () => {
  let emptyModel = {
    IsRelease: false,
    IsOpen: false,
    IsAdminOpen: false,
  };

  const [dropdownItem, setDropdownItem] = useState(null);
  const dropdownItems = [
      { name: 'Option 1', code: 'Option 1' },
      { name: 'Option 2', code: 'Option 2' },
      { name: 'Option 3', code: 'Option 3' }
  ];

  const [model, setModel] = useState(emptyModel);
    
  const onInputChange = (e, name) => {
    const val = (e.target && e.target.value) ?? '';
    let _model = { ...model };
    _model[`${name}`] = val;
    setModel(_model);
  };

  const onInputNumberChange = (e, name) => {
    const val = e.value || 0;
    let _model = { ...model };
    _model[`${name}`] = val;
    setModel(_model);
  };

  const onCheckedChange = (e, name) => {
    let _model = { ...model };
    _model[`${name}`] = e.target.checked;
    setModel(_model);
  };

    return (
        <div className="grid">
            <div className="col-12">
                <div className="card p-fluid">
                    <h5>Options</h5>
                    <div className="formgrid grid">
                        <div className="field col flex align-items-center">
                            <Checkbox inputId="IsRelease" name="IsRelease" value="Cheese" onChange={(e) => onCheckedChange(e, "IsRelease")} checked={model.IsRelease} />
                            <label htmlFor="IsRelease" className="ml-2">IsRelease</label>
                        </div>
                        <div className="field col">
                            <label htmlFor="IsOpen">IsOpen</label>
                            <Checkbox id="IsOpen" type="checkbox" />
                        </div>
                        <div className="field col">
                            <label htmlFor="IsAdminOpen">IsAdminOpen</label>
                            <Checkbox id="IsAdminOpen" type="checkbox" />
                        </div>
                        
                    </div>
                    <div className="formgrid grid">
                        <div className="field col">
                            <label htmlFor="name2">EmailVerificationTimeoutMinutes</label>
                            <InputText id="name2" type="number" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">PasswordResetTimeoutMinutes</label>
                            <InputText id="email2" type="number" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">SelectedCurrency</label>
                            <InputText id="email2" type="number" />
                        </div>
                        
                    </div>
                    <div className="formgrid grid">
                        <div className="field col">
                            <label htmlFor="name2">RequireUpperCaseInPassword</label>
                            <InputText id="name2" type="checkbox" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">RequireLowerCaseInPassword</label>
                            <InputText id="email2" type="checkbox" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">RequireSpecialCharacterInPassword</label>
                            <InputText id="email2" type="checkbox" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">RequireNumberInPassword</label>
                            <InputText id="email2" type="checkbox" />
                        </div>
                    </div>
                    
                    <div className="formgrid grid">
                        <div className="field col">
                            <label htmlFor="name2">ProductImageLimit</label>
                            <InputText id="name2" type="number" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">ProductCommentImageLimit</label>
                            <InputText id="email2" type="number" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">PagingProductCount</label>
                            <InputText id="email2" type="number" />
                        </div>
                        <div className="field col">
                            <label htmlFor="email2">ShowStock</label>
                            <InputText id="email2" type="checkbox" />
                        </div>
                    </div>
                    <br></br>
                    <br></br>
                    <Button label="Submit"></Button>
                </div>
            </div>
        </div>
    );
};

export default FormLayoutDemo;
