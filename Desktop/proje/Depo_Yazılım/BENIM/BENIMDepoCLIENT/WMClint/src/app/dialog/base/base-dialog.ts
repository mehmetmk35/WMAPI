import { MatDialogRef } from "@angular/material/dialog";

export class BaseDialog<DialogCompanent> {

    constructor(public dialogRef: MatDialogRef<DialogCompanent>) {}

    Close() 
    {
        this.dialogRef.close()
    }
} 
