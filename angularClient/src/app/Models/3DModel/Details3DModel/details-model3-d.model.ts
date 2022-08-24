import { Category } from "../../Category/category.model";

export class DetailsModel3D {
  public  id :string
  public  title: string
  public description :string
  public createdDate: string
  public category: Category
  public avtorId :string
  public isFileUploaded: boolean
  public  fileTitleWithoutExtension: string

  public  modelURL :string
}
