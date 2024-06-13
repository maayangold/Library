# library

## ספריה

### תיאור הפרויקט

מערכת לניהול ספרייה. באמצעות המערכת ניתן להשאיל ספרים למנויים, ולנהל את כלל הספרייה.

### ישויות

- ספר
- מנוי
- השאלה

### מיפוי Routes לספר

- שליפת רשימת הספרים - GET [https://localhost:7170/api/Books](https://localhost:7170/api/Books)
- שליפת ספר לפי מזהה - GET [https://localhost:7170/api/Books/1](https://localhost:7170/api/Books/1)
- הוספת ספר - POST [https://localhost:7170/api/Books](https://localhost:7170/api/Books)
- עדכון ספר - PUT [https://localhost:7170/api/Books/1](https://localhost:7170/api/Books/1)
- עדכון סטטוס ספר לספר מושאל - PUT [https://localhost:7170/api/Books/1/status](https://localhost:7170/api/Books/1/status)
- מחיקת ספר - DELETE [https://localhost:7170/api/Books/1](https://localhost:7170/api/Books/1)

### מיפוי Routes למנוי

- שליפת רשימת המנויים - GET [https://localhost:7170/api/Members](https://localhost:7170/api/Members)
- שליפת מנוי לפי מזהה - GET [https://localhost:7170/api/Members/1](https://localhost:7170/api/Members/1)
- הוספת מנוי - POST [https://localhost:7170/api/Members](https://localhost:7170/api/Members)
- עדכון מנוי - PUT [https://localhost:7170/api/Members/1](https://localhost:7170/api/Members/1)
- השאלת ספרים על ידי מנוי - POST [https://localhost:7170/api/Member/1/borrow](https://localhost:7170/api/Member/1/borrow)
- עדכון סטטוס מנוי - PUT [https://localhost:7170/api/Members/1/status](https://localhost:7170/api/Members/1/status)
- מחיקת מנוי - DELETE [https://localhost:7170/api/Members/1](https://localhost:7170/api/Members/1)

### מיפוי Routes להשאלה

- שליפת רשימת השאלות - GET [https://localhost:7170/api/Borrow](https://localhost:7170/api/Borrow)
- שליפת השאלה לפי מזהה - GET [https://localhost:7170/api/Borrow/1](https://localhost:7170/api/Borrow/1)
- הוספת השאלה - POST [https://localhost:7170/api/Borrow](https://localhost:7170/api/Borrow)
- עדכון השאלה - PUT [https://localhost:7170/api/Borrow/1](https://localhost:7170/api/Borrow/1)
- עדכון ספר להוספה בהשאלה - PUT [https://localhost:7170/api/Borrow/1/books/2](https://localhost:7170/api/Borrow/1/books/2)
- עדכון ספר להסרה מהשאלה - DELETE [https://localhost:7170/api/Borrow/1/books/2](https://localhost:7170/api/Borrow/1/books/2)
- עדכון סטטוס השאלה - PUT [https://localhost:7170/api/Borrow/1/status](https://localhost:7170/api/Borrow/1/status)
