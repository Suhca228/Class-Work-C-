#include <iostream>
#include <string>
#include <vector>

using namespace std;

class Student {
public:
    Student(const string& name, int age) : name_(name), age_(age) {}

    const string& name() const { return name_; }
    int age() const { return age_; }

private:
    string name_;
    int age_;
};

class ClassRoom {
public:
    ClassRoom() {}

    void add_student(const Student& student) { students_.push_back(student); }

    void print_all_students() const {
        for (const auto& student : students_) {
            cout << student.name() << ", " << student.age() << endl;
        }
    }

private:
    vector<Student> students_;
};

int main() {
    ClassRoom classroom;

    classroom.add_student(Student("Вася", 18));
    classroom.add_student(Student("Петя", 20));
    classroom.add_student(Student("Маша", 19));

    classroom.print_all_students();

}
