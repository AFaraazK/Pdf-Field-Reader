import PyPDF2
import test_path

def extract_pdf_fields(file_path):
    with open(file_path, 'rb') as document:
        doc_reader = PyPDF2.PdfFileReader(document)
        fields_dict = {}

        for page_num in range(doc_reader.numPages):
            page = doc_reader.getPage(page_num)
            fields = page.get('/Annots', [])
            for field in fields:
                field_obj = field.getObject()
                if field_obj.get('/FT') == '/Tx':
                    field_name = field_obj.get('/T')
                    field_value = field_obj.get('/V')
                    fields_dict[field_name] = field_value
        
        return fields_dict

fields_dict = extract_pdf_fields(test_path.file)
for field_name, field_value in fields_dict.items():
    print(f"Field: {field_name}, Value: {field_value}")
